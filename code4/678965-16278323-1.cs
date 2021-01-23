    public bool InsertUsername(string username)
    {
        string SQL = "Insert into [Users](Username, InsertDateTime) Values(@Username, datetime('now'));";
        var pars = new List<SQLiteParameter> {new SQLiteParameter("@Username", username)};
        return SQLiteUsernameDatabase.ExecuteNonQuery(SQL, pars);
    }
