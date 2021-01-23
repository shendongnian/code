    class Program 
    {
        [Flags]
        public enum Bar { Prop1, Prop2, Prop3 }
    
        public class Foo
        {
            public Bar SelectedBar { get; set; }
        }
    
        static void Main(string[] args)
        {
            var foo = new Foo();
            foo.SelectedBar = Bar.Prop1 | Bar.Prop2;
    
            foo.SelectedBar.HasFlag(Bar.Prop1); //true
            foo.SelectedBar.HasFlag(Bar.Prop2); //true
            foo.SelectedBar.HasFlag(Bar.Prop3); //false
        }
    }
