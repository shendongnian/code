    public static IEnumerable<FrameworkElement> FindVisualChildren(FrameworkElement obj, Func<FrameworkElement, bool> predicate)
    {
        if (obj != null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                var objChild = VisualTreeHelper.GetChild(obj, i);
                if (objChild != null && predicate(objChild as FrameworkElement))
                {
                    yield return objChild as FrameworkElement;
                }
                foreach (FrameworkElement childOfChild in FindVisualChildren(objChild as FrameworkElement, predicate))
                {
                    yield return childOfChild;
                }
            }
        }
    }
