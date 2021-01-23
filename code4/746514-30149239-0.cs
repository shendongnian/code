    List<string> SelectedItems = new List<string>();
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SelectedItems.Add((e.OriginalSource as CheckBox).Name.ToString());
        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            SelectedItems.Remove((e.OriginalSource as CheckBox).Name.ToString());
        }
