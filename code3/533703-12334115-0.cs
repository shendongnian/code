    public static void InsertText( string path, string newText )
    {
        if (File.Exists(path))
        {
            string oldText = File.ReadAllText(path);
            using (var sw = new StreamWriter(path, false))
            {
                sw.WriteLine(newText);
                sw.WriteLine(oldText);
            }
        }
        else File.WriteAllText(path,newText);
    }
