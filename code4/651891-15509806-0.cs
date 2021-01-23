    static void Main(string[] args)
        {
            object[] array = new object[4];
            array[0] = 1;
            array[1] = "1";
            array[2] = new object();
            array[3] = new StreamWriter(@"C:\file.txt");
            foreach (object o in array)
            {
                if (o != null)
                {
                    Console.WriteLine("Found an object!  It's type is: " + o.GetType());    
                }
                else
                {
                    Console.WriteLine("Didn't find an object");
                }
            }
            Console.ReadLine();
        }
