        static void Main(string[] args)
        {
            Random r = new Random();
            int[] myArray = new int[5];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = r.Next(0, 100);
                Console.WriteLine(myArray[i]);
            }
            Console.WriteLine("Press entere to find the max value");
            Console.Write(MaxArray(myArray));
            Console.Read();
        }
