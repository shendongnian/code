    public string GetMySpecId(string dataId)
    {
        return _dbHelper.ExecuteQuery(
            dr => 
               {
                   if(dr.Read())
                   {
                       return dr[0].ToString();
                   }
                   // do whatever makes sense here.
               },
            @"select ""specId"" from ""MyTable"" where ""dataId"" = :dataId",
            new SqlParameter("dataId", dataId));
        return result.Rows[0][0].ToString();
    }
