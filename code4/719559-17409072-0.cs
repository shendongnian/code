    private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                //selectedItemsId = (int)listBox1.SelectedValue;
                if (listBox1.ItemsSource != null)
                {
                    listBox1.Visibility = Visibility.Collapsed;
                }
    
                if (listBox1.SelectedIndex != -1)
                {
                    //remove the listener on the textbox
                    textBox1.TextChanged -= TextBoxBase_OnTextChanged;
                    textBox1.Text = listBox1.SelectedItem.ToString();
                    //put the listener back on the text box
                    textBox1.TextChanged += TextBoxBase_OnTextChanged;
                }
            }
