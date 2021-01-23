        private void SearchBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                string selecteditem = (string)e.AddedItems[0];
                this.SearchBox.Text = selecteditem;
            }
        }
        
