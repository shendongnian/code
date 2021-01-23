       //When this constructor is called 
       public RecursiveConstructor()
       {
           Console.WriteLine("Constructor one. Basic.");
           Init(One(), Two());
       }
    
       public RecursiveConstructor(int i, int j)
       {
           Console.WriteLine("Ctor 2");
           Init(i, j);
       }
    
    
       private void Init(int i, int j)
       {
           Console.WriteLine("Refactored");
           Console.WriteLine("Total = " + (i+j));
       }
