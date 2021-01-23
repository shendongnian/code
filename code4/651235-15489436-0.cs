    private void Create_File(string Create_Directory, string Create_Name)
    {
        string pathString = Create_Directory;
        if (!System.IO.Directory.Exists(pathString)) { System.IO.Directory.CreateDirectory(pathString); }
        pathString = System.IO.Path.Combine(pathString, Create_Name + ".txt");
        File.WriteAllText(fileName, Some_Method(MP.Mwidth, MP.Mheight, MP.Mtype, ""));
    }
