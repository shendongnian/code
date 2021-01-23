    static void FileSearch(string Base, string Pattern)
    {
        if (!Directory.Exists(Base)) return;
        string _Patt = Pattern.ToLower();
        var Files = Directory.GetFiles(Base).Where(File 
            => Path.GetFileName(File).ToLower().Contains(_Patt));
        foreach (string File in Files)
        {
            Console.WriteLine(File);
            if (Console.CursorTop % (Console.WindowHeight - 1) == 0)
                Console.ReadKey();
        }
        string[] Dirs = Directory.GetDirectories(Base);
        foreach (string Dir in Dirs)
            FileSearch(Dir, Pattern);
    }
