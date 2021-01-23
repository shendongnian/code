    System.IO.Stream fp = System.IO.File.OpenRead(@"C:\Path\To\My\File.txt");
    double x, y;
    using (var reader = new System.IO.BinaryReader(fp))
    {
        x = reader.ReadDouble();
        y = reader.ReadDouble();
    }
