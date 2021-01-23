     static void Main(string[] args)
        {
            int[] myArray = new int[] { 0, 11, 2, 15, 16, 8, 16 ,8,15};
            int Smallest = myArray.Min();
            int Largest = myArray.Max();
            foreach (int i in myArray)
            {
                if(i>Smallest && i<Largest)
                {
                    Smallest=i;
                }
            }
            System.Console.WriteLine(Smallest);
            Console.ReadLine();   
        }
