      public void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
      {
            ListBox listBox = sender as ListBox;
            if (listBox != null && listBox.SelectedItem != null)
            {
                // do work
            }
            listBox.SelectedIndex = -1;
      }
