    session.QueryOver<Definition>()
           .Where
            (
                Restrictions.Eq
                (
                    Projections.SqlProjection
                    (
                       "Data.value('(/Definition/Property/Value)[1]', 'int') as DefinitionId",
                       new string[] { "DefinitionId" },
                       new IType[] { NHibernateUtil.Int32 }
                    ),
                    5
                )
            )
           .List();
