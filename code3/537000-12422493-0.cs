    public class A
    {
       private int _p;
       public A(int param) { _p = param;}
    }
    
    public class B : A 
    {
        public B(int param) : base(param)
        {
        }
        public int x { get; set; }
    }
