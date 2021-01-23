    private void RunCheck()
    {
        // Checks all the websites.
        for (int i = 0; i < StkPan_Icons.Children.Count(); i++)
        {
            ClearImageStack(i);
            GetSiteAndCompare(i);
        }
    
        UpdateStatus();
    }
