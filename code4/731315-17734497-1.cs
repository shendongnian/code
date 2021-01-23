    static void Main()
    {
        var d = new D();
        var p = new P<D>();
        p.N(d);//Displays In class B
    }
     
    
    class B
    {
        public void M()// Note, not virtual
        {
            Console.WriteLine("In class B");
        }
    } 
    
    class D : B
    {
        public new void M()// new, not overload
        {
            Console.WriteLine("In class D");
        }
    } 
    
    class P<T> where T : B
    {
        public  void N(T t)
        {
            t.M();
        }
    }
