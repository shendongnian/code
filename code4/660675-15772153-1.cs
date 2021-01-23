    static void Main(string[] args)
        {
            double[] numbers = new double[10];
            int counter = 0;
            
            do
            {
                Console.WriteLine("Enter valid number or press X to exit");
                var t = Console.ReadLine();
                try
                {
                    double temp = double.Parse(t);
                    numbers[counter] = temp;
                    counter++;
                    
                }
                catch (Exception)
                {
                    if (t.Contains("X"))
                    {
                        break;
                    }
                    //Console.WriteLine("Enter valid number or press X to exit");
                }
            } while (counter<10);
            foreach (var number in numbers)
            {
                Console.Write("\nEntered number: "+number);
            }
            Console.ReadLine();
        }
