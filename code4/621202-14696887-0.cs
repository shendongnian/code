    var pointList = session
                    .CreateCriteria(typeof(PPoint), "p")
                    .CreateAlias("ImportFile", "f", NHibernate.SqlCommand.JoinType.InnerJoin)
                    .Add(Restrictions.Disjunction()
                        .Add(Restrictions.Like("p.Name", search, MatchMode.Anywhere))
                        .Add(Restrictions.Like("p.Code", search, MatchMode.Anywhere))
                        .Add(Restrictions.Like("p.Test1", search, MatchMode.Anywhere))
                        .Add(Restrictions.Like("p.Test2", search, MatchMode.Anywhere))
                        .Add(Restrictions.Like("f.FileName", search, MatchMode.Anywhere)))
                    .List<PPoint>();
