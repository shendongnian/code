        void Test()
        {
            DoIt(1, 2, 3, 4);
        }
        private void DoIt(params object[] p)
        {
            Console.WriteLine(p.Length);
            DoIt2(p);
            DoIt2(p, 5);
        }
        private void DoIt2(params object[] p)
        {
            Console.WriteLine(p.Length);
        }
