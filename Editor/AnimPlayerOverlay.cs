#if SCENEVIEW_OVERLAY_COMPATIBLE
using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine;

namespace Reallusion.Import
{
    [Overlay(typeof(SceneView), "Reallusion Import Tools", "Character Preview Tools")]
    public class AnimPlayerOverlay : IMGUIOverlay, ITransientOverlay
    {
        public static AnimPlayerOverlay createdOverlay { get; private set; }
        public static bool exists { get { return createdOverlay != null; } }        
        bool isVisible;
        public bool visible { get { return isVisible; } }
        
        AnimPlayerOverlay()
        {
            isVisible = false;
        }

        public void Show()
        {
            isVisible = true;
        }

        public void Hide()
        {
            isVisible = false;
        }

        public override void OnCreated()
        {            
            createdOverlay = this;
        }

        public override void OnGUI()
        {
            if (!FacialMorphIMGUI.useLightIcons) FacialMorphIMGUI.useLightIcons = true;
            AnimPlayerIMGUI.DrawPlayer();
            FacialMorphIMGUI.DrawFacialMorph();            
        }
    }
}
#endif
