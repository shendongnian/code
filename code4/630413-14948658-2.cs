    string userName = "";
    int[] v= new int[5];
    int sum = 0;
    float avg;
    float variance;
    Console.WriteLine("Please enter your name:");
    userName = Console.ReadLine();
    Console.WriteLine("Please enter in a number between 10 and 50: ");
    for (int i = 0; i < v.Length; i++)
    {
        int inputCheck = Convert.ToInt32(Console.ReadLine());
        while (inputCheck < 10 || inputCheck > 50)
        {
            Console.WriteLine("The number you have entered is invalid please enter a new variable: ");
            inputCheck = Convert.ToInt32(Console.ReadLine());
        }
        v[i] = inputCheck;
    }
