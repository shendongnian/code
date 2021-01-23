        var path = Server.MapPath("...");
        var images = Directory.GetFiles(path, "*.png");
        foreach (var image in images) 
        {
            System.Console.WriteLine(image);
        }
