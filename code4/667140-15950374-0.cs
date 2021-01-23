    class Animal {}
    class Lion : Animal { public void Roar() { } }
    class Giraffe : Animal { }
    interface IFoo { void M(Animal a); }
    class C : IFoo
    {
        public void M(Lion lion) { lion.Roar(); }
    }
    class P
    {
        public static void Main()
        {
            IFoo foo = new C();
            foo.M(new Giraffe()); 
        }
    }
