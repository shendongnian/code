    private void TextBox_KeyDown_1(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == VirtualKey.Enter)
        {
            this.Send.PerformClick();
        }
    }
    private void Send_Click(object sender, RoutedEventArgs e)
    {
        textBlock.Text = textBox1.Text;
        textBox1.Text = "";
    }
