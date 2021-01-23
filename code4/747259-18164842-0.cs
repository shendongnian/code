    using (var client = new System.Net.WebClient())
    {
        var data = client.DownloadData(url);
        System.IO.File.WriteAllBytes(filename, data);
        return LoadDrawableFromFile(context, filename);
    }
