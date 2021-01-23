    public static void FillUserListClass()
    {
        Dictionary<string, User> UserList = new Dictionary<string, User>();
        OleDbConnection conn = new OleDbConnection(strAccessConn);
        string query = "SELECT ControlNumber, UserName FROM Log WHERE Log.EndStatus in ('Needs Review', 'Check Search', 'Vision Delivery', 'CA Review', '1TSI To Be Delivered');";
    
        OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
        DataTable dt = new DataTable();
    
        try
        {
            adapter.Fill(dt);
    
            for (int ctr = 1; ctr <= dt.Rows.Count; ctr++)
            {
                var row = dt.Rows[ctr];
                var userName = row["UserName"].ToString();
                if (!UserList.ContainsKey(userName))
                {
                    UserList.Add(userName, new User()
                    {
                        UserName = userName,
                        ControlNumber = new List<int>()
                    });
                }
                UserList[userName].ControlNumber.Add((int)row["ControlNumber"]);
            }
        }
        catch (OleDbException ex)
        {
    
        }
        finally
        {
            conn.Close();
        }
    }
