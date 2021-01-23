    public class Foo<T> : Bar where T : Bar
    {
        public Foo()
        {
            // This obviously works
            var car = Bar.Cars.Honda;
            var name = Bar.Name;
    
            // use base class for enum accessor ?
            var car2 = Foo<T>.Cars.Toyota;
            var name2 = Foo<T>.Name;
            default(T).Accessor = "test"; // static member access
        }
    }
    public class Bar
    {
        public static string Name { get; set; }
        public enum Cars { Honda, Toyota };
        public virtual string Accessor
        {
            get { return Name; }
            set { Name = value; }
        }
    }
    
