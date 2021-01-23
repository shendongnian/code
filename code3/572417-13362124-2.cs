                double[] numbers1 = { 2.0, 2.1, 2.2, 2.3, 2.4, 2.5 };
                double[] numbers2 = { 2.2 };
    
                IEnumerable<double> onlyInFirstSet = numbers1.Except(numbers2);
    
                foreach (double number in onlyInFirstSet)
                    Console.WriteLine(number);
    
                /*
                 This code produces the following output:
    
                 2
                 2.1
                 2.3
                 2.4
                 2.5
                */
