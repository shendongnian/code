    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        string name = e.Parameter as string;
    
        if (!string.IsNullOrWhiteSpace(name))
        {
              textblock1.Text = name ;
        }
        else
        {
            textblock1.Text = "Name is required.  Go back and enter a name.";
        }
    }
