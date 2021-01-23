    private static object locker = new object();
    public static void Info(string user, string info, string txt)
    {        
        string str = Assembly.GetExecutingAssembly().GetName().CodeBase.ToString();
        string str3 = ...
        lock (locker)
        {
           File.AppendAllText(path, str3 + " " + info + " => " + txt + "\n");
        }
    }
