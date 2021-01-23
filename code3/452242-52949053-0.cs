    string pathAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
    string folderAssembly = System.IO.Path.GetDirectoryName(pathAssembly);
    if (folderAssembly.EndsWith("\\") == false) {
        folderAssembly = folderAssembly + "\\";
    }
    string folderProjectLevel = System.IO.Path.GetFullPath(folderAssembly + "..\\..\\");
