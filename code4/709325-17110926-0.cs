    for (int i = 0; i < 10; i++)
    {
        if (File.Exists(@"C:\name.txt"))
        {
            Process.Start(@"C:\bulkload.bat");
            return;
        }
        else //no need of else block really.
        {
            Thread.Sleep(30 * 60 * 1000);
        }
    }
