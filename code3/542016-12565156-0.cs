     static void Main(string[] args)
            {
                Console.WriteLine("enter array length ");
                int arraylength = Int32.Parse(Console.ReadLine());
                int[] AverageArray = new int[arraylength];
    
               
                for (int i = 0; i < AverageArray.Length; i++)
                {
                    Console.Write("enter the numbers you wish to find the average for: ");
                    AverageArray[i] = Int32.Parse(Console.ReadLine());
    
                }
               
                Console.WriteLine("here is your array: ");
                for (int i = 0; i < AverageArray.Length ; i++)
                {
                    Console.WriteLine(AverageArray[i]);
                }
    
                Console.WriteLine("here is the result");
                Console.WriteLine(Calcs.FindAverage(AverageArray));
                Console.ReadLine();
    
            }
