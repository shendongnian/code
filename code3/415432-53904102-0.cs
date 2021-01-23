                    int i = 0;
                    foreach (IPAPM_SRVC_NTTN_NODE_MAP item in ipapmList)
                    {
                        ++i;
                        if (i % 50 == 0)
                        {
                            ipdb.Dispose();
                            ipdb = null;
                            ipdb = new IPDB();
                            // .NET CORE
                            //ipdb.ChangeTracker.AutoDetectChangesEnabled = false; 
                            ipdb.Configuration.AutoDetectChangesEnabled = false;
                        }
                       
                        ipdb.IPAPM_SRVC_NTTN_NODE_MAP.Add(item);
                        ipdb.SaveChanges();
                    }                 
