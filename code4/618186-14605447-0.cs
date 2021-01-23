    void LogIn(string username, string password)
    {
        DataManager dm = new DataManager();
        int count = (int)dm.ExecuteScalar("user_check", CommandType.StoredProcedure,
        DataManager.CreateParameter("@username", SqlDbType.NVarChar, username),
            DataManager.CreateParameter("@pass", SqlDbType.NVarChar, password));
    }
