    public class Foo()
    {
        public Foo()
          : this(String.Empty)
        { }
        public Foo(string lastName)
          : this(lastName, String.Empty)
        { }
        public Foo(string lastName, string firstName)
          : this(lastName, firstName, 0)
        { }
        public Foo(string lastName, string firstName, int age)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            _SomeInternalState = new InternalState();
        }
    }
