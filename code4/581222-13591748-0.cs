    using (ITransaction tx = Session.BeginTransaction())
            {
                try
                {
                    Session.SaveOrUpdate(obj);
                    Session.Flush();
                    tx.Commit();
                }
                catch (HibernateException)
                {
                    tx.Rollback();
                    throw;
                }
            }
