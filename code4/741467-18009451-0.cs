    static void Main()
            {
                Console.Write("How many integers are in your list? ");
                int k = Convert.ToInt32(Console.ReadLine());
                int[] a = new int[k];
                int sum = 0;
    
                for (int i = 0; i < a.Length; i++)
                {
                    Console.Write("Please enter an integer: ");
                    a[i] = Convert.ToInt32(Console.ReadLine());
                }
                for (int n = 0; n < a.Length; n++)
                {
                    Console.WriteLine("{0, 5}", a[n]);
                }
                Console.WriteLine("-----");
    
                Console.Write("{0, 5}", a.Sum());
                Console.ReadLine();
            }
