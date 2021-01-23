    void LoadItems()
    {
        // Children.Clear();
        if (Items != null && (Children == null || Children.Count == 0))
        {
            StackPanel sp = CreateNewStackPanel();
            foreach (UIElement item in Items)
            {
                sp.Children.Add(item);
                if (sp.Children.Count == NumberOfColumns)
                {
                    Children.Add(sp);
                    sp = CreateNewStackPanel();
                }
            }
            if (sp.Children.Count > 0)
                Children.Add(sp);
        }
    }
