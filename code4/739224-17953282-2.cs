    class SinGenerator
    {
        Random r = new Random();
        /// <summary>
        /// Generates a valid 9-digit SIN.
        /// </summary>
        public int[] GetValidSin()
        {
            int[] s = GenerateSin();
            while (!SinIsValid(s))
                s = GenerateSin();  
            return s;
        }
        /// <summary>
        /// Generates a potential SIN. Not guaranteed to be valid.
        /// </summary>
        private int[] GenerateSin()
        {
            int[] s = new int[9];
            for (int i = 0; i < 9; i++)
                s[i] = r.Next(0, 10);
            return s;
        }
        /// <summary>
        /// Validates a 9-digit SIN.
        /// </summary>
        /// <param name="sin"></param>
        private bool SinIsValid(int[] sin)
        {
            if (sin.Length != 9)
                throw new ArgumentException();
            int checkSum = 0;
            for (int i = 0; i < sin.Length; i++)
            {
                int m = (i % 2) + 1;
                int v = sin[i] * m;
                if (v > 10)
                    checkSum += 1 + (v - 10);
                else
                    checkSum += v;
            }
            return checkSum % 10 == 0;
        }
    }
