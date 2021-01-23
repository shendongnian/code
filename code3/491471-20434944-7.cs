    using System.Diagnostics;
        private void Test()
        {
            Stopwatch sw = new Stopwatch();
            StringBuilder sb = new StringBuilder();
            int iterations = 1000;
            // Build a string of 1000000 space separated numbers
            for (var n = 0; n < iterations; n++)
            {
                if (n > 0)
                    sb.Append(' ');
                sb.Append(n.ToString());
            }
            string numberString = sb.ToString();
            // Time the process
            sw.Start();
            StringToInts(numberString, iterations);
            //StringToFloats(numberString, iterations);
            sw.Stop();
            long proc1 = sw.ElapsedMilliseconds;
            Console.WriteLine("iterations: {0} \t {1}ms", iterations, proc1);
        }
        private unsafe int[] StringToInts(string s, int length)
        {
            int[] ints = new int[length];
            int index = 0;
            int startpos = 0;
            fixed (char* pStringBuffer = s)
            {
                fixed (int* pIntBuffer = ints)
                {
                    for (int n = 0; n < s.Length; n++)
                    {
                        if (s[n] == ' ' || n == s.Length - 1)
                        {
                            if (n == s.Length - 1)
                                n++;
                            // pIntBuffer[index++] = int.Parse(new string(pStringBuffer, startpos, n - startpos));
                            pIntBuffer[index++] = ParseInt((pStringBuffer + startpos), n - startpos); 
                            startpos = n + 1;
                        }
                    }
                }
            }
            return ints;
        }
        private unsafe float[] StringToFloats(string s, int length)
        {
            float[] floats = new float[length];
            int index = 0;
            int startpos = 0;
            fixed (char* pStringBuffer = s)
            {
                fixed (float* pFloatBuffer = floats)
                {
                    for (int n = 0; n < s.Length; n++)
                    {
                        if (s[n] == ' ' || n == s.Length - 1)
                        {
                            if (n == s.Length - 1)
                                n++;
                            pFloatBuffer[index++] = ParseFloat((pStringBuffer + startpos), n - startpos); // int.Parse(new string(pStringBuffer, startpos, n - startpos));
                            startpos = n + 1;
                        }
                    }
                }
            }
            return floats;
        }
        public static unsafe int ParseInt(char* input, int len)
        {
            int pos = 0;           // read pointer position
            int part = 0;          // the current part (int, float and sci parts of the number)
            bool neg = false;      // true if part is a negative number
            int* ret = stackalloc int[1];
            while (pos < len && (*(input + pos) > '9' || *(input + pos) < '0') && *(input + pos) != '-')
                pos++;
            // sign
            if (*(input + pos) == '-')
            {
                neg = true;
                pos++;
            }
            // integer part
            while (pos < len && !(input[pos] > '9' || input[pos] < '0'))
                part = part * 10 + (input[pos++] - '0');
            *ret = neg ? (part * -1) : part;
            return *ret;
        }
        public static unsafe float ParseFloat(char* input, int len)
        {
            //float ret = 0f;      // return value
            int pos = 0;           // read pointer position
            int part = 0;          // the current part (int, float and sci parts of the number)
            bool neg = false;      // true if part is a negative number
            float* ret = stackalloc float[1];
            // find start
            while (pos < len && (input[pos] < '0' || input[pos] > '9') && input[pos] != '-' && input[pos] != '.')
                pos++;
            // sign
            if (input[pos] == '-')
            {
                neg = true;
                pos++;
            }
            // integer part
            while (pos < len && !(input[pos] > '9' || input[pos] < '0'))
                part = part * 10 + (input[pos++] - '0');
            *ret = neg ? (float)(part * -1) : (float)part;
            // float part
            if (pos < len && input[pos] == '.')
            {
                pos++;
                double mul = 1;
                part = 0;
                while (pos < len && !(input[pos] > '9' || input[pos] < '0'))
                {
                    part = part * 10 + (input[pos] - '0');
                    mul *= 10; 
                    pos++;
                }
                if (neg)
                    *ret -= (float)part / (float)mul;
                else
                    *ret += (float)part / (float)mul;
            }
            // scientific part
            if (pos < len && (input[pos] == 'e' || input[pos] == 'E'))
            {
                pos++;
                neg = (input[pos] == '-'); pos++;
                part = 0;
                while (pos < len && !(input[pos] > '9' || input[pos] < '0'))
                {
                    part = part * 10 + (input[pos++] - '0');
                }
                if (neg)
                    *ret /= (float)Math.Pow(10d, (double)part);
                else
                    *ret *= (float)Math.Pow(10d, (double)part);
            }
            return (float)*ret;
        }
