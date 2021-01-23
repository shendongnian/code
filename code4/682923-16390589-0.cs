    using (var documentSession = documentStore.OpenSession())
    {
        // We are doing an import, so allow us to do LOTS of queries to the db.
        documentSession.Advanced.MaxNumberOfRequestsPerSession = int.MaxValue;
        foreach (var foo in newFoosToImport())
        {
            var existingFoo = documentSession
                .Query<Foo>()
                .SingleOrDefault(x => x.Name == foo.Name);
            if (existingFoo == null)
            {
                // Doesn't exist, so just save this new data.
                documentSession.Store(foo);
            }
            else
                // Map the required new data to the existing object.       
                MapNewDataToExistingObject(foo, existingFoo);
    
                // Now save the existing.
                documentSessionStore(existingFoo);           
            }
        }
    
        // Commit these changes.
        documentSession.SaveChanges();
    }
