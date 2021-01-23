    class A
    {
        public void Foo() { }
    }
    class B
    {
        private A B = new A();
        static void Foo() { }
        void Bar()
        {
            B.Foo(); // what am I calling here?
        }
    }
