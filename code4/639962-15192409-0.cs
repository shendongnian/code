    private void button1_Click(object sender, RoutedEventArgs e)
    {
        if (Application.Current.Windows.OfType<win2>().Any())
        {
            Application.Current.Windows.OfType<win2>().First().Activate();
        }
        else
        {
            new win2().Show();      
        }
    }
