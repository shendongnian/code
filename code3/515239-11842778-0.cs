    private static IEnumerable<Person> ReadReader(IDataReader reader)
    {
        using (reader)
        {
            while (reader.Read())
            {
                yield return new Person
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Email = (string)reader["Email"],
                    PhoneNumber = (string)reader["PhoneNumber"]
                }
            }
        }
    }
