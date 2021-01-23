    class Class1
    {
        private List<int> _Abc(int a, int b)
        {
            // do job
            int x = 128, y = 256, z = 512;
            List<int> returns = new List<int>();
            returns.Add(x);
            returns.Add(y);
            returns.Add(z);
            return returns;
        }
        public void anotherMethod()
        {
            List<int> simple = new List<int>();
            simple = _Abc(55, 56);
            int[] _simple = simple.ToArray();
            for (int i = 0; i < simple.Count; i++)
            {
                Console.WriteLine("" + _simple[i]);
            }
            //Console.ReadKey();
        }
    }
