        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; ++i)
            {
                Func<Func<int, Task<String>>, Task<int>> t = 
                    async a => (await a(20)).Length + 10;
                Console.WriteLine(Peirce(t).Result); // output 20
                t = async a => 10;
                Console.WriteLine(Peirce(t).Result); // output 10
            }
        }
