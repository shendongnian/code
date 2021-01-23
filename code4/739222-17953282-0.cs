        bool SinIsValid(int[] sin)
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
