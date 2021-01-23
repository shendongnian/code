        static void Main(string[] args)
        {
            Base b = new Derived();
            b.E += (sender, eventArgs) => { Console.WriteLine("Event Handled"); };
            b.Raise();
        }
        abstract class Base
        {
            public abstract event EventHandler E;
            public abstract void Raise();
        }
        class Derived : Base
        {
            public override event EventHandler E;
            public override void Raise()
            {
                if (E != null)
                    E(this, null); // Resharper: Invocation of polymorphic field-like events
            }
        }
