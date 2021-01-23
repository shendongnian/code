    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool UpdateFrom(Person otherPerson)
        {
            bool change = false;
            change = Check(otherPerson.Name, p => p.Name, (p, val) => p.Name = val);
            change = change ||
                     Check(otherPerson.LastName, p => p.LastName, (p, val) => p.LastName = val);
            return change;
        }
        public bool Check(string value, Func<Person, string> getMember, Action<Person, string> action)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(value))
            {
                if (getMember(this) != value)
                {
                    result = true;
                    action(this, value);
                }
            }
            return result;
        }
    }
