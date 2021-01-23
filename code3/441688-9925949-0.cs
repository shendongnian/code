    public static void LogErrorMessage(Exception e)
    {
        using (StreamWriter w = File.AppendText(Server.MapPath("~/log.txt")))
        {
             Log(e.ToString(),w);
             w.Close();
        }
    }
