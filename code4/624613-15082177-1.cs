    private void autoCompleteBox1_LostFocus(object sender, RoutedEventArgs e)     
    {     
         if (autoCompleteBox1.SelectedItem == null && !string.IsNullOrEmpty(autoCompleteBox1.Text))
          {
           MessageBox.Show("Please fill in the right value");
           autoCompleteBox1.Text = "";
           autoCompleteBox1.Focus();
            }
    }
