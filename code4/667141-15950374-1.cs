    interface IBar { void M(Giraffe g); }
    class D : IBar
    {
        public void M(Animal animal) { ... }
    }
    class P
    {
        public static void Main()
        {
            IBar bar = new D();
            bar.M(new Giraffe()); 
        }
    }
