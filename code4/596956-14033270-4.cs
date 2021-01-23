    do
    {
       string inputString = Console.ReadLine();
       if(!Int32.TryParse(inputString, out input))     // will return false if it can't convert
       {
           Console.WriteLine("Please enter a number between 1 and 16!");
           input = 0;
       }
    }while(input == 0);
