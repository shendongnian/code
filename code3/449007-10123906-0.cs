    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        if (NavigationContext.QueryString.ContainsKey("PivotNada.SelectedIndex"))
        {
            int selectedIndex = -1;
            if(int.TryParse(NavigationContext.QueryString["PivotNada.SelectedIndex"].ToString(), out selectedIndex))
            {
                if(selectedIndex != -1)
                {
                    pivot.SelectedIndex = selectedIndex;
                }
            }
        }
    }
