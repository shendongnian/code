    Stream asset = context.Assets.Open(DATABASE_NAME + ".db");
    string dbPath = System.IO.Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
            "YourFile.xml");
    using (var dest = System.IO.File.OpenWrite(destPath))
        asset.CopyTo(dest);
