    while (choice != 0)
    {
        if (int.TryParse(Console.ReadLine(), out choice))
        {
           switch (choice)
           {
                case 0:
                   return; //returns from the FUNCTION! So from the switch AND while
                ....
                  
                ....
  
                ....
           }
        }
    }
