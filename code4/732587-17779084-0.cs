    //...
    using System.Text.RegularExpressions;
    using System.IO;
    //...
    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "file.txt");
     
    string yourString = Regex.Replace(File.ReadAllText(filePath, "file.txt")), "[^\\u0000-\\u007F]", "");
