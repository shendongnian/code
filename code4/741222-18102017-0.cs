            object a = null;
            return Session.QueryOver<T>()
                   .SelectList(l =>
                       l.Select(
                       Projections.GroupProperty(
                       Projections.SqlFunction("CANDIES", NHibernateUtil.Int32, Projections.Property(expression))
                       )).WithAlias(() => a)
