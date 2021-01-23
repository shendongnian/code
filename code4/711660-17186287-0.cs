        public static string GetExcelColumnName(int index)
        {
            int d = index;
            string name = "";
            int mod;
            while (d > 0)
            {
                mod = (d - 1) % 26;
                name = Convert.ToChar('a' + mod).ToString() + name;
                d = (int)((d - mod) / 26);
            }
            return name;
        }
        public static IEnumerable<string> GetExcelColumns(int n) {
            for (int i = 1; i <= n; i++)
            {
                yield return GetExcelColumnName(i);
            }
        }
        static void Main(string[] args)
        {
            int i = 1;
            foreach (var item in GetExcelColumns(900))
            {
                Console.Write(i++ + ": " + item + " ");
            }
            Console.WriteLine();
        }
