    foreach (var process in processes)
    {
        if (!process.HasExited)
        {
            process.CloseMainWindow();
            process.Close();
        }
    }
