    class Foo
    {
        internal class A
        {
            private Shared shared = new Shared();
        }
    
        internal class B
        {
            private Shared shared = new Shared();
        }
        
        private class Shared
        {
        }
    }
