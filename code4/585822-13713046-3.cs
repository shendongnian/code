    public string GetMySpecId(string dataId)
    {
        DataTable result = _dbHelper.ExecuteQuery(
            @"select ""specId"" from ""MyTable"" where ""dataId"" = :dataId",
            new SqlParameter("dataId", dataId);
        return result.Rows[0][0].ToString();
    }
