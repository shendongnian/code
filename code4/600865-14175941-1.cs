                    // Get my entity type (if in same assembly, else you'll have to specify)
                    Type postType = Type.GetType("Sandbox.Post");
                    using (var db = new StackOverflowEntities()) {                        
                        
                        // not required
                        db.Configuration.ProxyCreationEnabled = false;
                        IQueryable query = db.Set(postType);
                        foreach (var item in query) {
                            
                            DbEntityEntry entry = db.Entry(item);
                        }
                    }
