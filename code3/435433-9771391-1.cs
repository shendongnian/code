    public class SessionManagerSQLInterceptor : EmptyInterceptor, IInterceptor
    {
        //public string your property{ get; set; }  
        
        NHibernate.SqlCommand.SqlString IInterceptor.OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            NHSessionManager.Instance.NHibernateSQL = sql.ToString();
            //property = sql.ToString();
            //Or
            //AsignSqlToSomeGlobalVariable(sql.ToString());
            return sql;
        }
    }
