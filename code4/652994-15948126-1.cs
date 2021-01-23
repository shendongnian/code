       protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                title.Text = App.CurrentArticle.Titles;
               
                webBrowser.NavigateToString(App.CurrentArticle.FullContent);
               
            }
            base.OnNavigatedTo(e);
        }
