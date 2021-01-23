    class A
    {
        Ref<int> x;
        public A(Ref<int> x)
        {
            this.x = x;
        }
        public void Increment()
        {
            x.Value++;
        }
    }
    
    ...
    
    Ref<int> x = new Ref<int>(7);
    A a = new A(x);
    a.Increment();
    Debug.Assert(x.Value == 8);
