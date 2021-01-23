    string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    string privateAppFolder = Path.Combine(appFolder, "MyAppFolder");
    if(!Directory.Exists(privateAppFolder)) Directory.CreateDirectory(privateAppFolder);
    string myFile = Path.Combine(privateAppFolder, "Test.txt");
    using (StreamWriter writer = new StreamWriter(myFile, true))
    {
        writer.WriteLine("Last User:" +username );
    }
