    public class DbHelper : DbHelperCore
    {
        public DbHelper()
        {
            Connection = null;
            Transaction = null;
        }
        public static DbHelper instance
        {
            get
            {
                if (HttpContext.Current is null)
                    return new DbHelper();
                else if (HttpContext.Current.Items["dbh"] == null)
                    HttpContext.Current.Items["dbh"] = new DbHelper();
                return (DbHelper)HttpContext.Current.Items["dbh"];
            }
        }
        public override void BeginTransaction()
        {
            Connection = new SqlConnection(Entity.Connection.getCon);
            if (Connection.State == System.Data.ConnectionState.Closed)
                Connection.Open();
            Transaction = Connection.BeginTransaction();
        }
    }
