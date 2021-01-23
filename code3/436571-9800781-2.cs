    private void btn_next_Click(object sender, RoutedEventArgs e)
    {    
        listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
        ListBoxItem item = listBox1.SelectedItem as ListBoxItem;
        mediaElement1.Source = new System.Uri(item.Content as string); 
    }
