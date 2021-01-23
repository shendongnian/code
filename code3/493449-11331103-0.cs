    class MyDialect : NHibernate.Dialect.MySQLDialect
    {
        public MyDialect()
        {
            RegisterFunction("curdate", new NoArgSQLFunction("CurDate", NHibernateUtil.DateTime));
        }
    }
