    public static class ElementTreeHelper
        {
            public static T FindParent<T>(this DependencyObject child) where T : DependencyObject
            {
                if (child == null)
                    throw new ArgumentNullException("child");
    
                if (child is T)
                    return child as T;
    
                var current = child;
                while (current != null)
                {
                    if (current is Visual || current is Visual3D)
                        current = VisualTreeHelper.GetParent(current);
                    else
                    {
                        var previous = current;
                        current = LogicalTreeHelper.GetParent(previous) ?? previous.GetTemplatedParent();
                    }
    
                    if (current is T)
                        return current as T;
                }
    
                return null;
            }
    
            public static DependencyObject FindParent(this DependencyObject child, Type type)
            {
                if (child == null)
                    throw new ArgumentNullException("child");
    
                if (type == null)
                    throw new ArgumentNullException("type");
    
                if ((child.GetType().IsInstanceOfType(type)))
                    return child;
    
                var current = child;
                while (current != null)
                {
                    if (current is Visual || current is Visual3D)
                        current = VisualTreeHelper.GetParent(current);
                    else
                    {
                        var previous = current;
                        current = LogicalTreeHelper.GetParent(previous) ?? previous.GetTemplatedParent();
                    }
    
                    if (current != null 
                        && (current.GetType().IsInstanceOfType(type)))
                        return current;
                }
    
                return null;
            }
    
            public static DependencyObject GetTemplatedParent(this DependencyObject element)
            {
                DependencyObject parent = null;
                if (element is FrameworkElement)
                    parent = (element as FrameworkElement).TemplatedParent;
    
                if (element is FrameworkContentElement)
                    parent = (element as FrameworkContentElement).TemplatedParent;
    
                return parent;
            }
    
            public static Form FindForm(this DependencyObject element)
            {
                if (element == null)
                    return null;
    
                var source = PresentationSource.FromDependencyObject(element) as HwndSource;
                if (source == null)
                    return null;
    
                var host = Control.FromChildHandle(source.Handle) as ElementHost;
                if (host == null)
                    return null;
    
                var form = host.TopLevelControl as Form;
    
                return form;
            }
    
            public static IEnumerable<DependencyObject> GetVisualChildren(this DependencyObject parent)
            {
                if (parent == null)
                    throw new ArgumentNullException("parent");
    
                var count = VisualTreeHelper.GetChildrenCount(parent);
                if (count == 0)
                {
                    DependencyObject child;
                    if (parent.TryGetPropertyValue("Child", out child) && child != null)
                        yield return child;
                    else
                    {
                        IEnumerable children;
                        if (parent.TryGetPropertyValue("Children",out children) && children != null)
                        {
                            var dos = children.OfType<DependencyObject>();
                            foreach (var ch in dos)
                                yield return ch;
                        }
                    }
                }
    
                for (var i = 0; i < count; i++)
                    yield return VisualTreeHelper.GetChild(parent, i);
            }
    
            public static IEnumerable<DependencyObject> GetVisualChildrenSortedByTabIndex(this DependencyObject parent)
            {
                if (parent == null)
                    throw new ArgumentNullException("parent");
    
                return parent.GetVisualChildren().OrderBy(KeyboardNavigation.GetTabIndex);
            }
        }
