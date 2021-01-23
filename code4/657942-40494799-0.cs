    ISession ==> DbContext
    session.QueryOver<T> ==> dbContext.Set<T>
    session.Query<T> ==> dbContext.Set<T>
    Query<T>.Fetch() ==> Set<T>.Include()
    session.CreateSQLQuery ==> dbContext.Database.SqlQuery
    ClassMapping<T> ==> EntityTypeConfiguration<T>
