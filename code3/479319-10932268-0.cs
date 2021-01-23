    return session.CreateCriteria<Foo>()
                  .Add(Restrictions.Eq(
                           Projections.SqlFunction("date",
                                                   NHibernateUtil.Date,
                                                   Projections.Property("MyDate")),
                           day.Date))
                    .List<MyClass>(); //executes
