    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Student("John", 18, 1, "Stanford"));
            persons.Add(new Student("Matt", 20, 2, "Stanford"));
            persons.Add(new Teacher("Alice", 30));
            StudentDetails(persons);
        }
        private static void StudentDetails(List<Person> people)
        {
            foreach (Person p in people)
            {
                try
                {
                    Student s = (Student)p;
                    Console.WriteLine(s.ToString());
                }
                catch(InvalidCastException e)
                {
                }
            }
        }
    }
