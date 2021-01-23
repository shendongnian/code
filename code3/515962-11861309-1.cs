    // For copying...
    foreach (string s in files)
    {
       File.Copy(s, "C:\newFolder\newFilename.txt");
    }
    // ... Or for moving
    foreach (string s in files)
    {
       File.Move(s, "C:\newFolder\newFilename.txt");
    }
