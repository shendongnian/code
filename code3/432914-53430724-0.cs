      public static String ToSql(this ICriteria criteria)
        {
            var criteriaImpl = criteria as CriteriaImpl;
            var sessionImpl = criteriaImpl.Session;
            var factory = sessionImpl.Factory;
            var implementors = factory.GetImplementors(criteriaImpl.EntityOrClassName);
            var loader = new CriteriaLoader(factory.GetEntityPersister(implementors[0]) as IOuterJoinLoadable, factory, criteriaImpl, implementors[0], sessionImpl.EnabledFilters);
            return loader.SqlString.ToString();
        }
