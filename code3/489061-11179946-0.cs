    public T UpdatePost(DateTime DateUpdated, DateTime DateExpires, object Id) <-- DateTime parameters
            {
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        string hqlUpdate = string.Format(
                     "update {0} p set p.DateUpdated = :dateUpdated, p.DateExpires = :dateExpires where p.id = :id", typeof(T)); <-- passing the type of the entity.
                        session.CreateQuery(hqlUpdate)
                               .SetDateTime("dateUpdated",DateUpdated)
                               .SetDateTime("dateExpires", DateExpires)
                               .SetParameter("id", Id)
                               .ExecuteUpdate();
                        transaction.Commit();
                        return session.Get<T>(Id);
                    }
                }
            }
