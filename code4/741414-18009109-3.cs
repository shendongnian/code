    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        foreach (var child in rootGrid.Children)
        {
            if (child is TextBox)
            {
                System.Diagnostics.Debug.WriteLine(((TextBox)child).Text);
                if (string.IsNullOrEmpty(((TextBox)child).Text))
                {
                    //Empty text in this box
                }
            }
        }
    }
