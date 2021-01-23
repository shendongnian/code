    private void OnMouseDownClickCount(object sender, MouseButtonEventArgs e)
    {
        // Checks the number of clicks.
        if (e.ClickCount == 1)
        {
            // Single Click occurred.
            lblClickCount.Content = "Single Click";
        }
        if (e.ClickCount == 2)
        {
            // Double Click occurred.
            lblClickCount.Content = "Double Click";
        }
        if (e.ClickCount >= 3)
        {
            // Triple Click occurred.
            lblClickCount.Content = "Triple Click";
        }
    }
