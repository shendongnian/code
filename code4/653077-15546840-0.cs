    using System.IO;
    ...
    foreach (string file in Directory.EnumerateFiles(folderPath, "*.cs"))
    {
        string contents = File.ReadAllText(file);
    }
