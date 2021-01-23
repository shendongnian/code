    public static int UserInput()
    {
       int input =  int.Parse(Console.ReadLine());
       if (input < 1 || input > 4)
       {
           Console.Write("Invalid Selection. Enter a valid Number (1,2,3 or 4): ");
           return UserInput(); //<--- problem was here
       }
       return input; 
    }
