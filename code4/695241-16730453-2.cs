    class converter
    {
       public delegate void OnCopyComplete(string file);
       public event OnCopyComplete CopyComplete;
       public static void convert(object source, FileSystemEventArgs f)
       {
           //... some job done now NOTIFY the caller 
           if(CopyComplete != null) CopyComplete(source.ToString());
       }
    }
