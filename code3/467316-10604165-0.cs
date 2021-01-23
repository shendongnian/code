    public class SomeMutableClass
    {
        public string Name { get; set; }
    }
    // Two independent variables which have the same value
    SomeMutableClass x1 = new SomeMutableClass();
    SomeMutableClass x2 = x1;
    // This doesn't change the value of x1; it changes the
    // Name property of the object that x1's value refers to
    x1.Name = "Fred";
    // The change is visible *via* x2's value.
    Console.WriteLine(x2.Name); // Fred
