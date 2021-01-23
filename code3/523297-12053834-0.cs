            TabItem tab = new TabItem();
            tab.Header = "Search Page";
            SearchPage sp = new SearchPage();
            this.NavigationService.Navigate(sp);
            // ---------------------------------------------------- 
            var frame = new Frame(); // !
            frame.Navigate(sp);  // !
            tab.Content = frame; // !
            // ---------------------------------------------------- 
            tabControl.Items.Add(tab);
