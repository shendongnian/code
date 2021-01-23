    public OledbConnection createcon()
    {
       OledbConnection con = new OleDbConnection();
        string currentPath = Directory.GetCurrentDirectory();
        string DBPath = "";
        if (Directory.Exists(currentPath + @"\Database") == true)
        {
            DBPath = currentPath + @"\Database\SMAStaff.accdb";
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                currentPath = currentPath.Remove(currentPath.LastIndexOf("\\"));
            }
            DBPath = currentPath + "\\Database\\SMAStaff.accdb";
        }
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DBPath + ";" +
        "Persist Security Info = False;Jet OLEDB:Database Password=123";
         
        return con;
    }
