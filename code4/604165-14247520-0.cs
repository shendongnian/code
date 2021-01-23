        public List<Person> GetPeople(params string[] p)
        {
            var people = new List<Person>();
            using (var db = new DataContext())
            {
                var context = ((IObjectContextAdapter)db).ObjectContext;
                db.Database.Connection.Open();
                var command = db.Database.Connection.CreateCommand();
                command.CommandText = "SomeStoredProcedureReturningWeightedResultSetOfPeople";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                //Add parameters to command object
                people = context.Translate<Person>(command.ExecuteReader()).ToList();
            }
            return people;
        }
