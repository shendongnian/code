    public class ScrollAnimator {
      public static readonly DependencyProperty ScrollToProperty =
        DependencyProperty.RegisterAttached(
          "ScrollTo",
          typeof(double),
          typeof(ScrollAnimator),
          new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None, ScrollToChangedCallback));
    
      private static void ScrollToChangedCallback(
        DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs) {
        ScrollViewer viewer = GetScrollViewer(dependencyObject) as ScrollViewer;
        if (viewer != null)
          viewer.ScrollToVerticalOffset((double)dependencyPropertyChangedEventArgs.NewValue);
        // Modify Above code to however you want to do the animation.
      }
    
      public static DependencyObject GetScrollViewer(DependencyObject o) {
        if (o is ScrollViewer)
          return o;
    
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++) {
          var child = VisualTreeHelper.GetChild(o, i);
          var result = GetScrollViewer(child);
          if (result == null)
            continue;
          return result;
        }
        return null;
      }
    
      public static void SetScrollTo(UIElement element, Orientation value) {
        element.SetValue(ScrollToProperty, value);
      }
    
      public static Orientation GetScrollTo(UIElement element) {
        return (Orientation)element.GetValue(ScrollToProperty);
      }
    }
