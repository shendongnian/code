    Stream stream = myService.Query(new Uri(dlUrl));
    // declare the file name, replacing invalid characters
    string fileName = entry.Title.Text;
    string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
    Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
    fileName = r.Replace(fileName, "_");
    using (FileStream fstream = new FileStream(fileName +  "." + DownloaderSettings.Default.FileFormat,
        FileMode.Create,
        FileAccess.ReadWrite,
        FileShare.ReadWrite))
    {
        stream.CopyTo(fstream);
        fstream.Flush();
    }
