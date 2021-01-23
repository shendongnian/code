    var tiles = new List<Texture2D>();
    foreach (var imagePath in System.IO.Directory.GetFiles("Content/img/", ".xnb"))
    {
        var xnaPath = Path.Combine( "Content/img",
                                     Path.GetFileNameWithoutExtension(imagePath));
    
        tiles.Add( Content.Load<Texture2D>(xnaPath) );
    }
