    public class CustomMsSqlDialect : MsSql2005Dialect
    {
      public CustomMsSqlDialect()
      {
          RegisterFunction("accentinsensitivelike",
            new SQLFunctionTemplate(NHibernateUtil.String,
                "?1 COLLATE Latin1_general_CI_AI like ?2 collate Latin1_general_CI_AI"));
      }
    }
