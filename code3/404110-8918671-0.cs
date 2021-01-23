    static void Main(string[] args)
        {
            var mod = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven" };
            var OddNumbers = new List<string>();
            var EvenNumbers = new List<string>();
            int i = 0;
            foreach (var item in mod)
            {
                i = i + 1;
                if (i % 2 == 0)
                {
                    EvenNumbers.Add(item);
                }
                else
                {
                    OddNumbers.Add(item);
                }
            }
    }
            // but when you use an index in your loop I find it more readable to use this
            for (var j = 0; j < mod.Length; ++j)
            {
                if (j % 2 == 0)
                     OddNumbers.Add(mod[j]);
                else
                    EvenNumbers.Add(mod[j]);
            }
