    public static void Info(string user, string info, string txt)
    {        
        string str = Assembly.GetExecutingAssembly().GetName().CodeBase.ToString();
        File.AppendAllText(path, str3 + " " + info + " => " + txt + "\n");
    }
