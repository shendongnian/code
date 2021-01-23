    public void SetLabel(string text)
    {
        label1.Content = text;
    }
    protected void button2_Click(object sender, RoutedEventArgs e)
    {
         MainWindow x = new MainWindow();
         x.SetLabel("blabla");
    }
