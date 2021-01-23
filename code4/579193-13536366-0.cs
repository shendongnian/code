    private void LBX_AddTaskOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var SelItm = LBX_AddTaskOptions.SelectedItem as ListBoxItem;
            var StackPanel = SelItm.Content as StackPanel;
            foreach (var child in StackPanel.Children)
            {
                if(child is TextBlock)
                {
                    MessageBox.Show((child as TextBlock).Text);
                }
            }
    }
