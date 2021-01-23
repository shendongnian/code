    async void Button_Click(object sender, RoutedEventArgs e)
    {
        var t = Task.Run(() => StartAndWaitProcess(@"some\document\path"));
        await t;
        label.Content = "process finished";
    }
    void StartAndWaitProcess(string path)
    {
        using(var p = Process.Start(path))
            p.WaitForExit();
    }
