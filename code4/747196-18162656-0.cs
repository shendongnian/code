    var files = System.IO.Directory.GetFiles("C:\\Temp\\", "*.xml");
    foreach (string file in files)
    {
        var element = XElement.Load(file);
        Console.Write(element);
    }
