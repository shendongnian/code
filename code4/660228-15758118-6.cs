        static void Main(string[] args)
        {
            var generatedNum = new List<int>();
            var random = new Random();
            while (generatedNum.Count < 10)
            {
                var tempo = random.Next(0, 25);
                if (generatedNum.Contains(tempo)) continue;
                generatedNum.Add(tempo);
            }
            foreach (var i in generatedNum)
            {
                Console.WriteLine("{0}", i);
            }
        }
