    var files = new DirectoryInfo("Your path").GetFiles("*.*", SearchOption.AllDirectories);
    foreach(var file in files) 
    {
        using(var r = new StreamReader(file.OpenRead()))
        {
           string content = r.ReadToEnd();
           if(string.IsnullOrWhitespace(content))
           {
           // do stuff
           }
        }
    }
