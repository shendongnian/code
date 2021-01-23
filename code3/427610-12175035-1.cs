        private void MyListPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems != null && e.RemovedItems.Count > 0)
            {
                if (this.MyListPicker.SelectedItem != null)
                {              
                    // Do something
                }
            }  
        }
