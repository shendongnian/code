    public T SqlScalarResult<T>(System.Data.Entity.DbContext db, string function, System.Data.SqlClient.SqlParameter[] parameters) {
                
        List<string> functionArgs = new List<string>();
        foreach (System.Data.SqlClient.SqlParameter parameter in parameters) {
            functionArgs.Add("@" + parameter.ParameterName);
        }
        string sql = string.Format("SELECT dbo.{0}({1});", function, string.Join(",", functionArgs));
        return (T)db.Database.SqlQuery<T>(sql, parameters).FirstOrDefault();
    }
