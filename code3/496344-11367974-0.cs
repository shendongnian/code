        public Int32 getNthIndex(string str, char c, Int32 n)
        {
            Int32 index = 0;
            Int32 count = 0;
            if (str != null && str.Length > 0)
            {
                CharEnumerator scanner = str.GetEnumerator();
                while (scanner.MoveNext())
                {
                    if (scanner.Current == c) { count++; }
                    if (count == n) { break; }
                    index++;
                }
            }
            if (count == 0) { return -1; } else { return index; }
        }
