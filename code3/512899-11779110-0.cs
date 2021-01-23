    var files = (string[])e.Data.GetData(DataFormats.FileDrop);
    foreach (var filename in files)
    {
        var nameOnly = System.IO.Path.GetFileName(filename);
    }
