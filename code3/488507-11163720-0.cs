        public IEnumerable<Person> GetPersons(string name)
        {
            string connectionString = @"Password=nottelling;Persist Security Info=True;User ID=nottelling;Initial Catalog=customers;Data Source=db.example.com;";
            using (var connection = new SqlConnection(connectionString))
            {
                string command = string.Format(@"SELECT Fname, PersonID, Lname FROM Person Where Fname = '{0}'", name);
                connection.Open();
                using (var getperson = new SqlCommand(command, connection))
                using (var reader = getperson.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string PersonID = reader["PersonID"].ToString();
                        string PersonName = reader["Fname"].ToString();
                        PersonName += " ";
                        PersonName += reader["Lname"].ToString();
                        yield return new Person {PersonId = PersonID, Name = PersonName};
                    }
                }
            }
        }    
