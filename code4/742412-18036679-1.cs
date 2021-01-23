    string directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string path = Path.Combine(directory, "Accts.txt");
    foreach (string line in File.ReadLines(path))
    {
        foreach (char c in line)
        {
            // ...
        }
    }
