            private void comboBox8_Loaded(object sender, RoutedEventArgs e)
            {
                TextBox tb = (TextBox)(sender as ComboBox).Template.FindName("PART_EditableTextBox", (sender as ComboBox));
                if (tb != null)
                    tb.LostFocus += new RoutedEventHandler(tb_LostFocus);
            }
    
            void tb_LostFocus(object sender, RoutedEventArgs e)
            {
                ...
                else if (8int <= 7int && 8int >= 100)
                {
                    MessageBox.Show("Error description", "Error!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                ...
            }
