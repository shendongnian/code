    public static bool saveToDb(string name1,string nam2, DateTime dat)
    {
        bool ok=false;
        string sqlQuery = string.Format("INSERT into NumbersTable values ('{0}', '{1}','{2}')",name1,nam2,dat );
        SqlCommand s = new SqlCommand(sqlQuery, con);
        con.Open();
        s.ExecuteNonQuery();
        con.Close();
        return ok;
    }
