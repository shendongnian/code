    public abstract class Person
    {
        public string Name { get; private set; }  // The setter is private because we only have to set this name when we create an instance
        protected Person(string name)
        {
            Name = name;
        }
    }
    public class Male : Person
    {
        public Male(string name) : base(name)  // This constructor calls the constructor of the class it inherits and passes on the same argument
    }
    
    public class Female : Person
    {
        public Female(string name) : base(name)
    }
    public bool IsMatch(string needle, IEnumerable<Person> haystack)
    {
        var firstGirl = haystack.OfType<Female>().FirstOrDefault();
        var firstBuy = haystack.OfType<Male>().FirstOrDefault();
        return firstGirl != null &&
               firstGirl.Name == needle &&
               firstBoy != null &&
               firstBoy.Name != needle;
    }
