    static void Main(string[] args)
    {
        double[] numbers = new double[10];
        for (int count = 0; count < 10; count += 1)
        {
            double num;
            Console.WriteLine("Enter a number");
            
            while(!double.TryParse(Console.ReadLine(),out num))
            {
                 Console.WriteLine("Not a valid number");
                 Console.WriteLine("Enter a number");
            }
            numbers[count] = num
        }
        foreach(double item in numbers)
        {
            Console.WriteLine("{0}", item);
        }
        Console.ReadLine();
    }
