    string path = Path.GetTempFileName();//in reality, wrap this in try... so as not to leave hanging tmp files
    var response = client.Get<HttpWebResponse>("/foo/bar");
    
    long length;
    if (!long.TryParse(response.GetResponseHeader("X-Api-Length"), out length))
        length = -1;
    using (var fs = System.IO.File.OpenWrite(path))
        fs.CopyFrom(response.GetResponseStream(), new CopyFromArguments(new ProgressChange((x, y) => { Console.WriteLine(">> {0} {1}".Fmt(x, y)); }), TimeSpan.FromMilliseconds(100), length));
