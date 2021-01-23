    private static int _count;
    private void fileSystemWatcher_Changed(object sender, EventArgs e)
    {
        Console.WriteLine("fileSystemWatcher_Changed was called {0} times",
                          ++_count);
    }
