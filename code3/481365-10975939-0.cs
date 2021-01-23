    class A{
    }
    
    class B{
    }
    
    static void Main(string[] args)
    {
           ArrayList arr = new ArrayList();
           arr.Add(new A());
           arr.Add(new A());
           arr.Add(new A());
           arr.Add(new B());
           arr.Add(new A());
           int count= arr.ToArray().Count(x=> !x.GetType().Equals(typeof(A)));
    }
