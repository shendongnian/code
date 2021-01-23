     protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string index;
            int number=0;
            if (NavigationContext.QueryString.TryGetValue("id", out index))
            {
                if (Int32.TryParse(index, out number))
                {
                    PivotItem.SelectedIndex = number;
                }
            }
        }
