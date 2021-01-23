    ISQLFunction sqlAdd = new VarArgsSQLFunction("(", "+", ")");
    var concat = Projections.SqlFunction(sqlAdd, NHibernateUtil.String, Projections.Property("ObjectProperty1"), Projections.Property("ObjectProperty2"));
    var sha1 = Projections.SqlFunction("SHA1", NHibernateUtil.String, concat);
    ...
    session.CreateCriteria<Car>().Add(Expression.Eq(sha1, "hash"));
