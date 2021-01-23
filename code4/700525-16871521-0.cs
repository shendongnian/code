    public void Main()
            {
                const int NUMBERS_FROM = 1;
                const int NUMBERS_TO = 100;
    
                int n = int.Parse(Console.ReadLine());
                Random rnd = new Random();
                List<int> numbers = new List<int>();
    
                for (int i = 0; i < n; i++)
                {
                    int rndNumber = rnd.Next(NUMBERS_FROM, NUMBERS_TO + 1);
                    numbers.Add(rndNumber);
                }
    
                Console.WriteLine("Numbers : {0}",string.Join(", ",numbers));
            }
