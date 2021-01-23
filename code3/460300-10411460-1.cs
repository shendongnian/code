    public class Person
    {
        private string _firstName;
        private string _lastName;
        private DateTime _birthday;
        public FirstNameComparer
        {
            get
            {
                return new FirstNameComparer();  
            }
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
