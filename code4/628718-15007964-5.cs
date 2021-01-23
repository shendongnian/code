    using (var connection = new OracleConnection("a connection string")) {
        using (var schema1 = oraDbContext.Create("SCHEMA1", connection))
        using (var schema2 = oraDbContext.Create("SCHEMA2", connection)) {
            
            var query = ((from a in schema1.SomeTable1 select new { a.Field1 }).ToList())
                 .Concat((from b in schema2.SomeTable1 select new { b.Field1 }).ToList())
        }
    }
