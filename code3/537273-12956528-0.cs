    public static readonly DependencyProperty StealContextMenuProperty = 
        DependencyProperty.RegisterAttached(
            "StealContextMenu", 
            typeof(bool), 
            typeof(ParentClass),
            new UIPropertyMetadata(false, new PropertyChangedCallback(SCMChanged))
        );
    public static bool GetStealContextMenu(FrameworkElement obj)
    {
        return (bool)obj.GetValue(StealContextMenuProperty);
    }
    public static void SetStealContextMenu(FrameworkElement obj, bool value)
    {
        obj.SetValue(StealContextMenuProperty, value);
    }
    public static void SCMChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement fe = sender as FrameworkElement;
        if (fe == null) return;
        bool value = (bool)e.NewValue;
        if (!value) return;
        fe.Loaded += new RoutedEventHandler(fe_Loaded);
    }
    public static void fe_Loaded(object sender, RoutedEventArgs e)
    {
        FrameworkElement fe = (FrameworkElement)sender;
        FrameworkElement child;
        child = VisualDownwardSearch<FrameworkElement>(fe, x => x.ContextMenu != null);
        if (child != null)
        {
            fe.ContextMenu = child.ContextMenu;
            child.ContextMenu = null;
        }
    }
    public static T VisualDownwardSearch<T>(T source, Predicate<T> match)
        where T : DependencyObject
    {
        Queue<DependencyObject> queue = new Queue<DependencyObject>();
        queue.Enqueue(source);
        while(queue.Count > 0)
        {
            DependencyObject dp = queue.Dequeue();
            if (dp is Visual || dp is Visual3D)
            {
                int childrenCount = VisualTreeHelper.GetChildrenCount(dp);
                for (int i = 0; i < childrenCount; i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(dp, i);
                    if (child is T)
                    {
                        T tChild = (T)child;
                        if (match(tChild)) return tChild;
                    }
                    queue.Enqueue(child);
                }
            }
            else
            {
                foreach (DependencyObject child in LogicalTreeHelper.GetChildren(dp))
                {
                    if (child is T)
                    {
                        T tChild = (T)child;
                        if (match(tChild)) return tChild;
                    }
                    queue.Enqueue(child);                    
                }
            }
        }
        return null;      
    }
