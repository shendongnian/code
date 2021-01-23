       private static readonly Locker = new object();
       void Foo()
       {
              lock(Locker)
              {
                     dbEntities myEntity = new dbEntities();
                     var currentWork = myEntity.works.Where(xXx => xXx.RID == 208).FirstOrDefault();
                     Console.WriteLine("Access work");
                     if (currentWork != null)
                     {
                         Console.WriteLine("Access is not null");
                         currentWork.WordCount += 5;//Default WordCount is 0
                         Console.WriteLine("Count changed");
                         myEntity.SaveChanges();
                         Console.WriteLine("Save changes");
                     }
                     Console.WriteLine("Current Count:" + currentWork.WordCount);
              }
       }
