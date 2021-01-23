    static Dictionary<string, List<int>> UserList = new Dictionary<string, List<int>>();
    public static void FillUserListClass(DataTable dt)
    {
        for (int ctr = 0; ctr < dt.Rows.Count; ctr++)
                    {
                        var row = dt.Rows[ctr];
                        var userName = row["User"].ToString();
    
                        if (UserList.ContainsKey(userName))
                        {
                            UserList[userName].Add(Convert.ToInt32(row["ControlNumber"]));
                        }
                        else
                        {
                            UserList.Add(row["User"].ToString(), new List<int>());
                            UserList[userName].Add(Convert.ToInt32(row["ControlNumber"]));
                        }
        }
