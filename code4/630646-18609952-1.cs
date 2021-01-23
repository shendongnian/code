    namespace Demo.Controls
    {
       public class ScrollViewerWithTouch : ScrollViewer
       {
        private PanningMode panningMode;
  
        private bool panningModeSet;
    
          static ScrollViewerWithTouch()
          {
             DefaultStyleKeyProperty.OverrideMetadata(typeof(ScrollViewerWithTouch), new FrameworkPropertyMetadata(typeof(ScrollViewerWithTouch)));
          }
    
          protected override void OnManipulationCompleted(ManipulationCompletedEventArgs e)
          {
             base.OnManipulationCompleted(e);
    
             // set it back
             this.PanningMode = this.panningMode;
          }
    
          protected override void OnManipulationStarted(ManipulationStartedEventArgs e)
          {
             // figure out what has the user touched
             var result = VisualTreeHelper.HitTest(this, e.ManipulationOrigin);
             if (result != null && result.VisualHit != null)
             {
                var hasButtonParent = this.HasButtonParent(result.VisualHit);
    
                // if user touched a button then turn off panning mode, let style bubble down, in other case let it scroll
                this.PanningMode = hasButtonParent ? PanningMode.None : this.panningMode;
             }
             base.OnManipulationStarted(e);
          }
    
          protected override void OnTouchDown(TouchEventArgs e)
          {
             // store panning mode or set it back to it's original state. OnManipulationCompleted does not do it every time, so we need to set it once more.
             if (this.panningModeSet == false)
             {
                this.panningMode = this.PanningMode;
                this.panningModeSet = true;
             }
             else
             {
                this.PanningMode = this.panningMode;
             }
    
             base.OnTouchDown(e);         
          }
    
          private bool HasButtonParent(DependencyObject obj)
          {
             var parent = VisualTreeHelper.GetParent(obj);
    
             if ((parent != null) && (parent is ButtonBase) == false)
             {
                return HasButtonParent(parent);
             }
    
             return parent != null;
          }
       }
    }
