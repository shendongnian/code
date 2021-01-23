     Control ctrl = null;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (ctrl != null)
            {
                TextBox tb = ctrl as TextBox;
                tb.Text += Convert.ToString(button1.Content);
            }
        }
    
    
        private void textBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            ctrl = (Control)sender;
        }
    
        private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            ctrl = (Control)sender;
        }
