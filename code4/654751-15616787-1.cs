    public static class VisualTreeHelperEx
    {
        public static IEnumerable<DependencyObject> GetVisualChildren(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            return GetVisualChildrenAndSelfIterator(element).Skip(1);
        }
        public static IEnumerable<DependencyObject> GetVisualChildrenAndSelfIterator(DependencyObject element)
        {
            Debug.Assert(element != null, "element should not be null!");
            yield return element;
            int count = VisualTreeHelper.GetChildrenCount(element);
            for (int i = 0; i < count; i++)
            {
                yield return VisualTreeHelper.GetChild(element, i);
            }
        }
    }
