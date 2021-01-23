    else if (type == "cups")
    
          {
    
            Console.WriteLine("Enter a number of liters to be converted into cups.");
            amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(cupsTolitConverter.Convert(amount) + " cups to said number of liters.");
    
          }
