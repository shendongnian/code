    private static int _count;
    private object lockerObject = new object();
    private void fileSystemWatcher_Changed(object sender, EventArgs e)
    {
        lock(lockerObject)
        {
            Console.WriteLine("fileSystemWatcher_Changed was called {0} times",
                      ++_count);
        }
    }
