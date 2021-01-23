    string filename =
       Path.Combine(
           Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
           "Test1.txt");
    string[] lines = File.ReadAllLines(filename);
    var list = new List<string>(lines);
    list.RemoveAt(4);
    File.WriteAllLines(filename, list.ToArray());
