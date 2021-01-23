    int MenuChoice = 0;
    while (MenuChoice != 4)
    {
        MenuChoice = Convert.ToInt32(Console.ReadLine());
        MenuChoice = int.Parse(Console.ReadLine()); 
   
        // switch here.
        MenuChoice++;
        if (MenuChoice < 30)
            continue;
        else
            break;
        }
    }
