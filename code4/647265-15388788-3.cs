    class Foo 
    { 
        public Foo() 
        {
            this.x = whatever;
            this.y = whatever;
            SideEffects.Alpha(); // Does not use "this"
        }
        ~Foo() 
        { 
            SideEffects.Charlie(); 
        }
        ...
    }
    static class SideEffects
    {
        public static void Alpha() {...}
        public static void Bravo() {...}
        public static void Charlie() {...}
        public static void M()
        {
            Foo foo = new Foo(); // Allocating Foo has side effect Alpha
            Bravo();
            // Foo's destructor has side effect Charlie
        }
    }
