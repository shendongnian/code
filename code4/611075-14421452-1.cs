    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        TextBox1.Text += "More Text";
        if (TextBox1.LineCount >= 2)
        {
            TextBox1.Height = 38; 
        }
        if (TextBox1.LineCount >= 3)
        {
            TextBox1.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }
    }
