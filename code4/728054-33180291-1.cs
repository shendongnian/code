        static void Main(string[] args)
        {
            Base b = new MostDerived();
            b.E += (sender, eventArgs) => { Console.WriteLine("Event Handled"); };
            b.Raise();
        }
        class MostDerived : Derived
        {
            public override event EventHandler E;
        }
        
