        interface Test
       {
             void abc();
       }  
       class DerivedClass : ParentClass, Test //Test should not be a class. It can be  a interface.
    {
         public DerivedClass()
         {
             Console.WriteLine("Derived class constructor!");
         }
         public void abc()
         {
              //should be publicly defined!
              //non public method could not implement from interface Test
         }
    }
     class ParentClass
    {
         public ParentClass()
         {
             System.Console.WriteLine("Parent class constructor!");
         }
    }
   
