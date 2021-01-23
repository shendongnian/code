    // uie is a UIElement
    IEnumerable<ScrollViewer> svList = uie.GetVisualDescendants<ScrollViewer>();
    if (svList.Count() > 0)
    {
        // Visual States are always on the first child of the control
        FrameworkElement element = VisualTreeHelper.GetChild(svList.First<ScrollViewer>(), 0) as FrameworkElement;
        // getting all the visual state groups
        IList groups = VisualStateManager.GetVisualStateGroups(element);
        foreach (VisualStateGroup group in groups)
        {
            if (group.Name == "ScrollStates")
            {
                group.CurrentStateChanged += new EventHandler<VisualStateChangedEventArgs>(group_CurrentStateChanged);
            }
        }
    }
    private static void group_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
    {
        if (e.NewState.Name == "NotScrolling")
        {
            isNotScrolling = true;
        }
        else
        {
            isNotScrolling = false;
        }
    }
