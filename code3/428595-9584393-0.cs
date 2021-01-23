    class A 
    { 
        public PointF Position {get;set;} 
 
        public A(PointF point) 
        { 
            this.Position = point; 
        } 
    } 
    A a = new A(new PointF(1,2));    
        a.Position.X = 100  
        Console.WriteLine(a.Position.X); 
