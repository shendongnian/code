    public class PersonService : IPerson
    {
        public Person SetCustomer(Dictionary<Guid, Person> info)
        {
            foreach (var person in info.Values)
            {
                Console.WriteLine("Name: {0} | Email: {1}", person.Name, person.Email);
            }
    
            var p = new Person { Name = "John Doe", Email = "John@Doe.com" };
            return p;
        }
    }
