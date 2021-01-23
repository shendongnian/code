    const String pluginPath = "Plugins";
    
    var pluginAssets = Assets.List(pluginPath);
    foreach (var pluginAsset in pluginAssets)
    {
        var file = Assets.Open(pluginPath + Java.IO.File.Separator + pluginAsset);
    
        using (var memStream = new MemoryStream())
        {
            file.CopyTo(memStream);
    
            //do something fun.
            var assembly = System.Reflection.Assembly.Load(memStream.ToArray());
            Console.WriteLine(String.Format("Loaded: {0}", assembly.FullName));
        }
    
    }
