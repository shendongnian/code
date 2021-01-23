    if (Letter == 'a')
    {
        name = name1;
        getsales();
        calcComm();
    }
    else if (Letter == 'b')
    {
         name = name2;
         getsales();
         calcComm();
    }
    else if (Letter == 'e')
    {
         name = name3;
         getsales();
         calcComm();
    }
    else
    {
        Console.WriteLine("Invalid entry try again");
        inputLetter = Console.ReadLine();
    }
