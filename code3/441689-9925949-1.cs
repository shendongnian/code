    public static void LogErrorMessage(Exception e, string Directory)
    {
        using (StreamWriter w = File.AppendText(Directory + "/log.txt"))
        {
             Log(e.ToString(),w);
             w.Close();
        }
    }
