     private void DemoAutoComplete_LostFocus(object sender, RoutedEventArgs e)
                {
                    DemoTextBox.Visibility = Visibility.Visible;
                    DemoAutoComplete.Visibility = Visibility.Collapsed;
                    DemoTextBox.Text = OCRAutoComplete.Text;
    
                    ((DemoVM)this.DataContext).SelectedDemoText = DemoAutoComplete.Text;
                }
    
    
    
    private void DemoTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            DemoAutoComplete.Text = OctTextBox.Text;
            DemoTextBox.Visibility = Visibility.Collapsed;
            DemoAutoComplete.Visibility = Visibility.Visible;
            DemoAutoComplete.Focus();
        }
