    class Foo
    {
        private void PrivateMethod()
        {
        }
        class FooBaby
        {
            public static void MethodB()
            {
                Foo foo = new Foo();
                foo.PrivateMethod();
            }
        }
    }
