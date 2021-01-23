    private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Counter = 123;
            Settings.Default.Save();
        }
