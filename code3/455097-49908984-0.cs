    public static class DependencyObjectExtensions
    {
        public static T FirstOrDefaultChild<T>(this DependencyObject parent, Func<T, bool> selector) 
            where T : DependencyObject
        {
            T foundChild;
            return FirstOrDefaultVisualChildWhere(parent, selector, out foundChild) ? foundChild : default(T);
        }
        private static bool FirstOrDefaultVisualChildWhere<T>(DependencyObject parent, Func<T, bool> selector,
            out T foundChild) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                var tChild = child as T;
                if (tChild != null)
                {
                    if (!selector(tChild)) continue;
                    foundChild = tChild;
                    return true;
                }
                if (FirstOrDefaultVisualChildWhere(child, selector, out foundChild))
                {
                    return true;
                }
            }
            foundChild = default(T);
            return false;
        }
