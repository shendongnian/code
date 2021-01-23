    private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
     {
                if (e.Key == Key.Enter)
                {
                    MessageBox.Show("Enter key pressed");
                }
                else if (e.Key == Key.Space)
                {
                    MessageBox.Show("Space key pressed");
                }
    }
