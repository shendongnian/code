        string[] lines = File.ReadAllLines(@"TEST.txt");
        foreach (var line in lines.Where(line => line.Length > 0))
        {
            double[] numbers = line.Split(',')
                                .Select(number => 
                                    Convert.ToDouble(number))
                                    .ToArray();
            int index = 1;
            Console.WriteLine(numbers.Length > index ? numbers[index].ToString() : String.Empty);
            index = 3;
            Console.WriteLine(numbers.Length > index ? numbers[index].ToString() : String.Empty);
            Console.WriteLine();
        }
