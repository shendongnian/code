    public void Edit()
    {
        TextBox.Text = TextBlock.Text;
        TextBlock.Visibility = System.Windows.Visibility.Collapsed;
        TextBox.Visibility = System.Windows.Visibility.Visible;
        Dispatcher.BeginInvoke((ThreadStart)delegate
        {
            Keyboard.Focus(TextBox);
            TextBox.SelectAll();
        });
    }
