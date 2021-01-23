    public class CulturFilter : FilterDefinition
    {
      public CulturFilter()
      {
        WithName("CulturFilter")
            .AddParameter("culture",NHibernate.NHibernateUtil.String);
      }
    }
