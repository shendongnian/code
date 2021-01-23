    foreach (string checkedItem in checkedListBox1.CheckedItems)
    {
       if (checkedItem.Contains("."))
       {
           string baseName = Path.GetFileNameWithoutExtension(checkedItem);
           string processPath = Path.Combine(pad, "data", baseName, checkedItem); 
           Process process = Process.Start(processPath);
           process.WaitForExit();
       }
    }
