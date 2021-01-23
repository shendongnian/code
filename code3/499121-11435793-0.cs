    // ...
    var process = Process.GetProcessesByName(listBox1.Items[i].ToString()).FirstOrDefault();
    
    if (process != null)
    {
        foreach (var handle in EnumerateProcessWindowHandles(process.Id))
        {
            // ...
        }
    }
    // ...
