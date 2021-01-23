        class ClassA
    {
        public ClassA()
        {
            Console.WriteLine("Initialization");
        }  
    }
    
    class ClassB : ClassA
    {
        public ClassB() //: base() 
        {
            // Using :base() as commented above, I would execute ClassA ctor before                                                         //          Console.WriteLine as it is below this line... 
            Console.WriteLine("Before new");
            //base() //Calls ClassA constructor using inheritance
            //Run some more Codes here...
        }
    }
    void main(string[] args)
        {
          ClassB b = new ClassB();
            
        }
