        private static void PrintLastNLines(string str, int n)
        {
            int idx = str.Length - 1;
            int newLineCount = 0;
            while (newLineCount < n)
            {
                if (str[idx] == 'n' && str[idx - 1] == '\\')
                {
                    newLineCount++;
                    idx--;
                }
                idx--;
            }
            PrintFromIndex(str, idx + 3);
        }
        private static void PrintFromIndex(string str, int idx)
        {
            for (int i = idx; i < str.Length; i++)
            {
                if (i < str.Length - 1 && str[i] == '\\' && str[i + 1] == 'n')
                {
                    Console.WriteLine();
                    i++;
                }
                else
                {
                    Console.Write(str[i]);
                }
            }
            Console.WriteLine();
        }
