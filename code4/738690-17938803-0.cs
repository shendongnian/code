     class A{
                public static void display()
                {
                        Console.WriteLine("In class A");
                }
        }
          class B : A
          {
              public void display()
              {
                  Console.WriteLine("In class B");
              }
              public static void show()
              {
                  A.display(); 
              }
          }
