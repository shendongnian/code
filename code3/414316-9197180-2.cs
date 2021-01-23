    public class Foo()
    {
        public Foo(string lastName, string firstName, int age)
          : this(lastName, firstName)
        {
            Age = age;
        }
        public Foo(string lastName, string firstName)
          : this(lastName)
        {
            FirstName = firstName;
        }
        public Foo(string lastName)
          : this()
        {
            LastName = lastName;
        }
        public Foo()
        {
            _SomeInternalState = new InternalState();
        }
    }
