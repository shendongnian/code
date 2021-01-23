    class Person
    {
        public int Age;
    }
    class AgeEqualityTester : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Age == y.Age;
        }
        public int GetHashCode(Person obj)
        {
            return Age.GetHashCode;
        }
    }
