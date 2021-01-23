    static void test()
    {
        string s = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
        s.Replace("##path##", Directory.GetCurrentDirectory());
        OleDbConnection conn = new OleDbConnection(s);
    }
