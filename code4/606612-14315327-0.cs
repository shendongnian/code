        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.NavigationMode != System.Windows.Navigation.NavigationMode.Back)
            {
                
                if (NavigationContext.QueryString.TryGetValue("add", out lister))
                {
                    sklad = lister;
                    ((App)Application.Current).myList.Add(sklad);
                }
                listBox1.ItemSource = ((App)Application.Current).myList;
            }
        }
