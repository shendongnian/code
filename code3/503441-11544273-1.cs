        // Note: Increase FACTOR depending on how many decimal places of accuracy you need.
        private const float FACTOR = 10;
        public void Test()
        {
            for (float i = 0; i < 1000; i += 0.1F)
            {
                Console.WriteLine("{0} {1}", i, Oscillate(2.5F, 7.5F, i));
            }
        }
        private float Oscillate(float min, float max, float time)
        {
            return (float)(Oscillate_Aux(Upscale(min), Upscale(max), Upscale(time))) / FACTOR;
        }
        private int Upscale(float value)
        {
            return (int)(value * FACTOR);
        }
        private int Oscillate_Aux(int min, int max, int time)
        {
            int range = max - min;
            int multiple = time / range;
            bool ascending = multiple % 2 == 0;
            int modulus = time % range;
            return ascending ? modulus + min : max - modulus;
        }
