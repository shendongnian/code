    public class A
        {
            public A(B b)
            {
                B = b;
            }
    
            public B B { get; set; }
        }
    
        public class B
        {
            public B(C c)
            {
                C = c;
            }
    
            public C C { get; set; }
        }
    
        public class C
        {
            public C(int id)
            {
                this.Id = id;
            }
    
            public int Id { get; set; }
        }
