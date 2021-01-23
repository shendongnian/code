        enum alphabets { a = 1, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z }
        static void Main()
        {
            Console.WriteLine("Enter string");
            string UserString = Console.ReadLine();
            int len = UserString.Length;
            int row = 1, column = 3;
            
            if (len % 2 == 0)
            {
                row = len / 2;
                column = len / 2;
                PrintMatrix(row, column, len, UserString);
            }
            Console.ReadKey();
        }
        static void PrintMatrix(int row, int column, int len, string value1)
        {
            Console.WriteLine("Matrix");
            string mat_row = value1.Substring(0, row);
            string mat_col = value1.Substring(row, len - row);
            int[] arrayRow = GenNum(mat_row, len);
            int[] arrayCol = GenNum(mat_col, len);
        }
        static int[] GenNum(string val, int len)
        {
            string res = val;
            int[] intArray = new int[len];
            int index = 0;
            foreach (char c in res)
            {
                string name = c.ToString();
                alphabets parsed = (alphabets)Enum.Parse(typeof(alphabets), name);
                int NumGen = (int)parsed;
                intArray[index++] = NumGen;
                Console.WriteLine(NumGen);
            }
            return intArray;
        }
