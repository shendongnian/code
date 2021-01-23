    class Program
    {
        static void Main(string[] args)
        {
            Person myPerson = new Person("Wenda");
            System.Console.WriteLine("myPerson is " + myPerson.name);       // Prints "myPerson is Wenda"
            if (myPerson == Person.Waldo)
                System.Console.WriteLine("Found Waldo (first attempt)");    // doesn't happen
            else
                System.Console.WriteLine("Still trying to find Waldo...");  // Prints "Still trying to find Waldo..."
            myPerson.name = "Bozo";
            System.Console.WriteLine("myPerson is now " + myPerson.name);   // Prints "myPerson is now Bozo"
            myPerson = Person.Waldo;
            if (myPerson == Person.Waldo)
                System.Console.WriteLine("Found Waldo (second attempt)");   // Prints "Found Waldo (second attempt)"
            System.Console.WriteLine("myPerson is " + myPerson.name);       // Prints "myPerson is Waldo"
            System.Console.WriteLine("Now changing to The Joker...");       // Prints "Now changing to The Joker"
            try
            {
                myPerson.name = "The Joker";                                // throws ImmutablePersonModificationAttemptException
            }
            catch (ImmutablePersonModificationAttemptException)
            {
                System.Console.WriteLine("Failed to change");               // Prints "Failed to change"
            }
            System.Console.WriteLine("myPerson is now " + myPerson.name);   // Prints "myPerson is now Waldo"
            Thread.Sleep(int.MaxValue); // keep the console alive long enough for me to see the result.
        }
    }
    public class Person
    {
        public static readonly ImmutablePerson Waldo = new ImmutablePerson("Waldo");
        public virtual string name { get; set; }
        public Person() // empty base constructor required by ImmutablePerson(string) constructor
        { }
        public Person(string name)
        {
            this.name = name;
        }
    }
    public class ImmutablePersonModificationAttemptException : Exception
    { }
    public class ImmutablePerson : Person
    {
        private bool allowMutation;
        protected string _name;
        public override string name
        {
            get
            {
                return _name;
            }
            set
            {
                if (allowMutation)
                    _name = value;
                else
                    throw new ImmutablePersonModificationAttemptException();
            }
        }
        public ImmutablePerson(string name)
            : base()
        {
            allowMutation = true;
            this.name = name;
            allowMutation = false;
        }
    }
