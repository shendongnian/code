    public static class NHibernateExtensions {
      public static IList<TRes> ListAs<TRes>(
          this IQueryOver qry, TRes resultByExample) {
    
        var ctor = typeof(TRes).GetConstructors().First();
    
        return qry.UnderlyingCriteria
          .SetResultTransformer(
            Transformers.AliasToBeanConstructor(
             (ConstructorInfo) ctor)
            ).List<TRes>();
      }
    }
