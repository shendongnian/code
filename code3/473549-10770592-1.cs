    public class PointDataTemplateSelector : DataTemplateSelector {
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            var element = container as FrameworkElement;
            if (element != null && item != null && item is Point) {
                var point = (Point)item;
                // Logic here.
                if (point.X >= 5) {
                    return element.FindResource("buttonTemplate") as DataTemplate;
                }
                return element.FindResource("textTemplate") as DataTemplate;
            }
            return null;
        }
    }
