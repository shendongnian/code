    var files = new DirectoryInfo("Your path").GetFiles("*.*", SearchOption.AllDirectories);
    foreach(var file in files) 
    {
        string content = new StreamReader(file.OpenRead()).ReadToEnd();
        if(string.IsnullOrWhitespace(content))
        {
          // do stuff
        }
    }
