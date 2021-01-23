    public T UpdatePost(Object DateUpdated, object DateExpires, object Id)
    {
        using (var session=sessionFactory.OpenSession())
        {
            using (var transaction=session.BeginTransaction())
            {
                string hqlUpdate = 
                     "update Post p set p.DateUpdated = :dateUpdated, p.DateExpires = :dateExpires where p.id = :id";
                session.CreateQuery(hqlUpdate)
                       .SetDateTime("dateUpdated", DateUpdated)
                       .SetDateTime("dateExpires", DateExpires)
                       .SetParameter("id", Id)
                       .ExecuteUpdate();
                transaction.Commit();
                return session.Get<T>(Id);
            }
        }
    }
