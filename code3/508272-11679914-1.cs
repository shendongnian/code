                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        // Business Entity Saved in Tag1/Tag2 Table
                        session.SaveOrUpdate(l);
                        session.Flush();  // <<== Write all of our changes so far
                    }
                    catch (Exception ex)
                    {
                        ErrorLogExceptionHandler.ErrorLog(ref ex);
                        throw new Exception("Unable to save data");
                    }
