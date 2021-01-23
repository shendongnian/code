    public class Person
    {
        private int _age;
        public Person(int someAge)
        {
            _age = someAge;
        }
    
        public int Age
        {
            get { return _age; }
        }
    
        public Person Grow()
        {
            return new Person(_age + 1);
        }
    }
