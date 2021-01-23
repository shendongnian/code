        public void Test()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("{0} {1}", i, Oscillate(2, 7, i));
            }
        }
        private int Oscillate(int min, int max, int time)
        {
            int range = max - min;
            int multiple = time / range;
            bool ascending = multiple % 2 == 0;
            int modulus = time % range;
            return ascending ? modulus + min : max - modulus;
        }
