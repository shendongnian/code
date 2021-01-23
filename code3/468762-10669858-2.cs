    public void button1_Click(object sender, RoutedEvent e)
    {
      AboutData dataContext = (sender as Button).DataContext as AboutData;
      dataContext.Enabled = false;
    }
