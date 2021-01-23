    static void output(Array arr)
        {
    
            foreach (int i in arr)
            {
                for (int v = 1; v <= arr.Length; v++)
                {
                    string number = "Number: ";
    
                    Console.WriteLine("{0}{1} {2}", number, v, i);
                    Console.ReadLine();
                }
            }
        }
