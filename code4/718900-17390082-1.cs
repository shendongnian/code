    void PrintText(object sender, SelectionChangedEventArgs args)
    {
      object item = listBox1.SelectedItem;
      if (item == null) {
        txtSelectedItem.Text = "No item currently selected.";
      } else {
        txtSelectedItem.Text = item.ToString();
      }
      // ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
      //  String a =  lbi.Content.ToString();
      Window1 neww = null;
      neww = new Window1();
      neww.Show();
    }
