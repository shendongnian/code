    public class Container<T>
    {
        public T Value { get; protected set; }
    
        public Container(T value)
        {
            Value = value;
        }
    }
    
    public class FirstName : Container<string>
    {
        public FirstName(string firstName) : base(firstName) { }
    }
    
    public class LastName : Container<string>
    {
        public LastName(string lastName) : base(lastName) { }
    }
    
    public class Age : Container<int>
    {
        public Age(int age) : base(age) { }
    }
    
    public class Program
    {
        public void Process(FirstName firstName, LastName lastName, Age age)
        {
        }
    }
