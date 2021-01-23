    namespace Extension
    {
        public static class FrameworkElementExtensions
        {
            public static FrameworkElement FindDescendantByName(this FrameworkElement element, string name)
            {
                if (element == null || string.IsNullOrWhiteSpace(name))
                {
                    return null;
                }
                if (name.Equals(element.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return element;
                }
                var childCount = VisualTreeHelper.GetChildrenCount(element);
                for (int i = 0; i < childCount; i++)
                {
                    var result = (VisualTreeHelper.GetChild(element, i) as FrameworkElement).FindDescendantByName(name);
                    if (result != null)
                    {
                        return result;
                    }
                }
                return null;
            }
        }
    }
