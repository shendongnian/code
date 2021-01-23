    public List<Entity> GetEntities()
    {
        using (var context = new CensusEntities())
        {
            var combinedResult = (from e in context.Entities
                select new {
                    Entity = e,
                    CollectedValues = new
                                      {
                                          // Insert default values of the correct type as placeholders
                                          col1 = 0, // or "" for string or false for bool
                                          col2 = 0, // or "" for string or false for bool
                                          // ...
                                          col49 = 0, // or "" for string or false for bool
                                          col50 = 0, // or "" for string or false for bool
                                      }
            );
            // Then copy each requested property
            // col1
            if (useCol1)
            {
                var combinedResult = (from e in combinedResult
                    select new {
                        Entity = e,
                        CollectedValues = new
                                          {
                                              col1 = e.Enitity.col1, // <-- here we update with the real value
                                              col2 = e.CollectedValues.col2, // <-- here we just use any previous value
                                              // ...
                                              col49 = e.CollectedValues.col49, // <-- here we just use any previous value
                                              col50 = e.CollectedValues.col50, // <-- here we just use any previous value                                          }
                );
            }
            // col2
            if (useCol2)
            {
             // same as last time
                                              col1 = e.CollectedValues.col1, // <-- here we just use any previous value
                                              col2 = e.Enitity.col2, // <-- here we update with the real value
                                              // ...
            }
            // repeat for all columns, update the column you want to fetch
            // Just get the collected objects, discard the temporary
            // Entity property. When the query is executed here only
            // The properties we actually have used from the Entity object
            // will be fetched from the database and mapped.
            return combinedResult.Select(x => x.CollectedValues).ToList()
            .Select(x=>new Entity{col1 = x.col1, col2 = x.col2, ... col50 = x.col50}).ToList();
        }
    }
