    class A { }
    class B : A { }
    class Test
    {
        public void MethodName( )
        {
            var obj = new Container<A>();
            obj.Set(new B());
        }
    }
