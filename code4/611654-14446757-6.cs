    class SomeClass
    {
        public ObservableProperty<double> SomeDouble { get; private set; }
        public SomeClass()
        {
            SomeDouble = new ObservableProperty<double>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SomeClass someobject = new SomeClass();
            const double lam = 1.0;
            using (var sub = someobject.SomeDouble.Observable
                .TakeWhile((oldvalue, newvalue) => 
                    Math.Abs(oldvalue - newvalue) > lam)
                .Subscribe(x => 
                    Console.WriteLine("{0}\t{1}",x,someobject.SomeDouble.Value)))
            {
                someobject.SomeDouble.Value = 3.0;
                someobject.SomeDouble.Value = 2.0;
                someobject.SomeDouble.Value = 1.0;
                someobject.SomeDouble.Value = -1.0;
            }
        }
    }
