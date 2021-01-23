        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string linkurl= "";
            
            if (NavigationContext.QueryString.TryGetValue("link", out linkurl))
                textBlock1.Text = linkurl;
           
        }
