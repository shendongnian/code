    public static class PersonExtensions
    {
        public static string WhoAreYou(this IPerson person)
        {
            return "My name is " + person.Name + " and I'm " + person.Age + " years old.";
        }
    }
