    public void AddOrUpdate(IList<Foo> foos)
    {
        var foosToUpdate = db.Foos.Where(x => foos.Contains(x)).ToList();
        var foosToInsert = foos.Except(foosToUpdate).ToList();
        foreach (var foo in foosToUpdate)
        {
            var f = db.Foos.First(x => someEqualityTest(x));
            // Update the existing foo
            f = foo;
        }
        // Insert the new Foos to the table named "Foos"
        db.BulkInsert("Foos", foosToinsert);
        db.SaveChanges();
    }
