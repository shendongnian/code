    static void Main(string[] args)
        {
            int n = 0;
            var up = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    n++;
                }
            });
            up.Start();
            up.Join();
            for (int i = 0; i < 1000000; i++)
            {
                n--;
            }
            Console.WriteLine(n);
            Console.ReadLine();
        }
