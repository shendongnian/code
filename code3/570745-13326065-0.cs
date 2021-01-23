    double balance, interestRate, targetBalance; //creating three doubles
    Console.WriteLine("What is your current balance?"); //writing to the console
    balance = Convert.ToDouble(Console.ReadLine()); //reading what the user inputs & converting it to a double
    Console.WriteLine("What is your current annual interest (in %)?");
    interestRate = 1 + Convert.ToDouble(Console.ReadLine()); //same as above
    Console.WriteLine("What balanec would you like to have?");
    targetBalance = Convert.ToDouble(Console.ReadLine()); //same as above
    int totalYears = 0; //creates an int variable for the total years
    if (balance < targetBalance)
    {
        do
        {
            balance *= interestRate; //multiplying balance x interest rate
            ++totalYears; // adding 1 to the total years
        }
        while (balance < targetBalance); //only do the above when balance is less than target balance
            Console.WriteLine("In {0} year{1} you'll have a balance of {2}.", totalYears, totalYears == 1 ? "" : "s", balance); //writing the results to the console
        }
     }
     else if (targetBalance < balance)
     {
         Console.WriteLine("Your balance is bigger than the target amount");
     }
     Console.ReadKey(); //leaving the results there until the user inputs a key
