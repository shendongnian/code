    public class People : IEnumerable<Person>
    {
        List<Person> persons = new List<Person>();
        public IEnumerator<Person> GetEnumerator()
        {
            return persons.GetEnumerator();
        }
    }
