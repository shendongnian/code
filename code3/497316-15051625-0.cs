        static void Main(string[] args)
        {
            int i,j;
            string[] str = new string[10];
            Console.WriteLine("Enter the Name of your friends");
            for (i = 0; i < 10; i++)
            {
                str[i] = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Array["+i+"]="+str[i]);
            }
            Console.ReadLine();
        }
    }
