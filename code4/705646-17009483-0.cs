    string table = cbTables.SelectedItem.ToString();
    using (var dbContext = new Entities()) {
        Dictionary<string, DbSet> mapping = new Dictionary<string, DbSet> {
            { "Person", dbContext.Person },
            { "Student", dbContext.Student },
            { "Grade", dbContext.Grade }
        };
        //...
