    private async void button1_Click(object sender, RoutedEventArgs e)
    {
        button1.IsEnabled = false;
        try
        {
            var s = await Task.Factory.StartNew(() => File.ReadAllLines("Words.txt").ToList());
            // do something with s
        }
        finally
        {
            button1.IsEnabled = true;
        }
    }
