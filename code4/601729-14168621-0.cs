    void y_Click(object sender, RoutedEventArgs e)
    {
        CheckBox che = lbox.SelectedItem as CheckBox;
        if (che == null) return;    // <--- Add this
        if ((bool)che.IsChecked)
        {
            MessageBox.Show(che.Content.ToString());
        }
    }
