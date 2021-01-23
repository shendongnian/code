    DirectoryInfo dI = new DirectoryInfo(@"C:\Users\Dave");
    List<string> files = new List<string>();
    foreach (DirectoryInfo subDI in dI.GetDirectories())
    {
            if ((subDI.Attributes & (FileAttributes.ReparsePoint | FileAttributes.System)) !=
            (FileAttributes)0)
                  continue;
            files.Add(subDI.FullName);
    }
