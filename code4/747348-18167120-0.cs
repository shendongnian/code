    FunWithScheduling fun = new FunWithScheduling();
     Console.WriteLine("This Is Your Scheduler");
     Console.WriteLine("What Do You Wish To Do");
     Console.WriteLine("Enter 1 To Add, 2 To Edit, 3 To Search And 4 To Exit");
     int Choice = Convert.ToInt32(Console.ReadLine());
     switch (Choice)
     {
              case 1:
                  fun.Add();
                  break;
              case 2:
                  fun.Edit();
                  break;
              case 3:
                  fun.Search();
                  break;
              case 4:
                  fun.Exit();
                  break;
             Default:
                   Console.WriteLine("Enter a Valid Number");   
                   return;
      }
 }
