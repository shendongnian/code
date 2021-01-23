    class A { 
       
        public virtual void Print() { 
              Console.WriteLine("Called from A");
        }      
    }
    class B : A { 
        public override void Print() { 
              Console.WriteLine("Called from B");
        }  
     }
