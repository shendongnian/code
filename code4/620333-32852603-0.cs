    public class ScrollViewerExtension : DependencyObject
    {
        public static readonly DependencyProperty ScrollViewerZoomFactorProperty = DependencyProperty.RegisterAttached(
            "ScrollViewerZoomFactor", typeof(double), typeof(ScrollViewerExtension), new PropertyMetadata(default(double), OnZoomFactorChanged));
        public static void SetScrollViewerZoomFactor(DependencyObject element, double value)
        {
            element.SetValue(ScrollViewerZoomFactorProperty, value);
        }
        public static double GetScrollViewerZoomFactor(DependencyObject element)
        {
            return (double)element.GetValue(ScrollViewerZoomFactorProperty);
        }
        private static void OnZoomFactorChanged(DependencyObject depObject, DependencyPropertyChangedEventArgs args)
        {
            if (depObject is ScrollViewer)
            {
                var scrollViewer = (ScrollViewer)depObject;
                var zoomValue = (double)args.NewValue;
                if (!Double.IsNaN(zoomValue))
                    scrollViewer.ZoomToFactor((float)zoomValue);
            }
            else
            {
                throw new Exception("ARE YOU KIDDING ME ? ITS NOT SCROLLVIEWER");
            }
        }
    }
