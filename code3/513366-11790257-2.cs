            string[] lines = File.ReadAllLines("d:\\TEST.txt");
            foreach (var line in lines.Where(line => line.Length > 0))
            {
                string[] numbers = line.Split(',');
                // It checks whether numbers.Length is greater than 
                // 3 because if maximum index used is 3 (numbers[3]) 
                // than the array has to contain at least 4 elements
                if (numbers.Length > 3)
                {
                    double a = Convert.ToDouble(numbers[1]);
                    Console.Write(a);
                    int b = Convert.ToInt32(numbers[3]);
                    Console.Write(b);
                    Console.WriteLine();
                }
            }
