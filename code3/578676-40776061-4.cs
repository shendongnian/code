    using System.Reflection;
    using System.IO;
    private static void RecordEvents(string someEvent)
    {
        string folderLoc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!folderLoc.EndsWith(@"\")) folderLoc += @"\";
        folderLoc = folderLoc.Replace(@"\\", @"\"); // replace double-slashes with single slashes
        string myFilePath = folderLoc + "myEventFile.txt";
        if (!File.Exists(myFilePath))
            File.Create(myFilePath).Close(); // must .Close() since will conflict with opening FileStream, below
        FileStream fs = new FileStream(myFilePath, FileMode.Append);
        StreamWriter sr = new StreamWriter(fs);
        sr.Write(someEvent + Environment.NewLine);
        sr.Close();
        fs.Close();
    }
