    public class Person
    {
        private string _firstName;
        private string _lastName;
        private DateTime _birthday;
        private FirstNameComparer firstNameComparer = new FirstNameComparer();
        public int CompareFirstNames(Person x, Person y)
        {
           return firstNameComparer.Compare(x, y);
        }
        //...
    
        private class FirstNameComparer : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x._firstName.CompareTo(y._lastName);
            }
        }
    }
