    private async void button1_Click(object sender, RoutedEventArgs e)
    {
        button1.IsEnabled = false;
        var s = await ReadAllLinesAsync("Words.txt").ToList();
        // do something with s
        button1.IsEnabled = true;
    }
