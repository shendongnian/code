    private void but_Click(object sender, RoutedEventArgs e)
    {
        Button but = (sender as Button)
        if(but.IsEnabled)
        {
           but.IsEnabled = false;
           doSomeThing();
           but.IsEnabled = true;
        }
    }
