        static Random r = new Random(2);
        static void Main(string[] args)
        {
            
            int d = r.Next(-15, 15);
            while ((d >= -15 && d <= -10) || (d >= 10 && d <= 15))
                Console.WriteLine(d);
            Console.ReadLine();
        }
