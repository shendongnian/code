    static double GetTestMark()
    {
       double testMark; // Declare a local
       Console.WriteLine("Your test result: ");
       testMark = double.Parse(Console.ReadLine());
       return testMark;
    }
