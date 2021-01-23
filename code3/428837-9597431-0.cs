    public class MsSql2008ExtendedDialect : MsSql2008Dialect
    {
      public MsSql2008ExtendedDialect()
      {
        RegisterFunction("DATEPART_YEAR", 
          new SQLFunctionTemplate(NHibernateUtil.DateTime, "datepart(year, ?1)"));
      }
    } 
