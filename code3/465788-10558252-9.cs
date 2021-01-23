    Dictionary<string, object> paras = new Dictionary<string, object>();
    paras.Add("user_name", "Timmy");
    paras.Add("date", DateTime.Now);
    using(SqlDataReader results = executeProcedure("sp_add_user", paras))
    {
        while (results.Read())
        {
            //do something with the rows returned
        }
    }
