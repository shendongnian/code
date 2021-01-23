        public static class MyClassHelper
        {
          public static void Output(this MyClass1 item1)
          {
            Console.Write(item1.Id);
            Console.Write("-");
            foreach (var item2 in item1.MyClasses2)
            {
              Console.Write(item2.Id);
              Console.Write("-");
              foreach (var item3 in item2.MyClasses3)
              {
                Console.Write(item3.Id);
                Console.Write("-");
                Console.Write(item3.Property1);
              }
            }
            Console.WriteLine();
          }
          public static IEnumerable<MyClass1> Flatten(this IEnumerable<MyClass1> list)
          {
            foreach (var item1 in list)
            {
              foreach (var item2 in item1.MyClasses2)
              {
                foreach (var item3 in item2.MyClasses3)
                {
                  yield return new MyClass1 
                   { 
                     Id = item1.Id, 
                     MyClasses2 = new[] 
                     { 
                       new MyClass2 { Id = item2.Id, MyClasses3 = new[]{item3}.ToList()}
                      }.ToList() 
                   };
                }
              }
            }
          }
        }
