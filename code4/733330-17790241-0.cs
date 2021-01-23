     private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                foreach (var selectedItem in e.AddedItems)
                {
                    switch ((selectedItem as ListBoxItem).Content.ToString())
                    {
                        case "name 1":
                            MessageBox.Show("X");
                            break;
                        case "name 2":
                            MessageBox.Show("y");
                            break;
                        default:
    
                            break;
                    }
                }
            }
