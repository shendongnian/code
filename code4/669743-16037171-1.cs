                using (var txn = _session.BeginTransaction())
                {
                    try
                    {
                        var user= new User
                            {
                                Name = "embarus"
                            };
                        _session.Save(user);
                        txn.Commit();
                    }
                    catch (UniqueKeyException)
                    {
                        txn.Rollback();
                        var msg = string.Format("A user named '{0}' already exists, please enter a different name or cancel.", "embarus");
                        // Do something useful
                    }
                    catch (Exception ex)
                    {
                        if (txn.IsActive)
                        {
                            txn.Rollback();
                        }
                        throw;
                    }
                }
