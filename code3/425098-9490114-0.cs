    class Test { 
         public Test Other { get; set;} 
         static void Main()
         {
              Test one = new Test();
              Test two = new Test { Other = one; }
              one.Other = two;
              one = null;
              two = null
              // Both one and two still reference each other, but are now eligible for GC
         }
    }
