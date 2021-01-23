    public static void AppendAllText(string path, string contents)
    {
      // Removed some checks
      File.InternalAppendAllText(path, contents, StreamWriter.UTF8NoBOM);
    }
    
    internal static Encoding UTF8NoBOM
    {
      get
      {
        if (StreamWriter._UTF8NoBOM == null)
        {
          StreamWriter._UTF8NoBOM = new UTF8Encoding(false, true);
        }
        return StreamWriter._UTF8NoBOM;
      }
    }
