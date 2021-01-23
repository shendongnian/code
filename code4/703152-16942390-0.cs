        static void Main(string[] args)
        {
            IEnumerable<string> strings = new[] { "1", "2", "3", "10", "20", "30", "Dog", "Cat", "30Dog", "30Cat" };
            strings = strings.OrderBy(s => s, new CustomComparer());
            var joined = string.Join(" ", strings);
            Console.WriteLine(joined);
            Console.ReadLine();
        }
        public class CustomComparer : IComparer<string>
        {
            public int Compare(string s1, string s2)
            {
                int x, y;
                bool xInt, yInt;
                xInt = int.TryParse(s1, out x);
                yInt = int.TryParse(s2, out y);
                if (xInt && yInt)
                    return x.CompareTo(y);
                if (xInt && !yInt)
                {
                    if (this.SplitInt(s2, out y, out s2))
                    {
                        return x.CompareTo(y);
                    }
                    else
                    {
                        return -1;
                    }
                }
                if (!xInt && yInt)
                {
                    if (this.SplitInt(s1, out x, out s1))
                    {
                        return y.CompareTo(x);
                    }
                    else
                    {
                        return 1;
                    }
                }
                return s1.CompareTo(s2);
            }
            private bool SplitInt(string sin, out int x, out string sout)
            {
                x = 0;
                sout = null;
                int i = -1;                
                bool isNumeric = false;
                var numbers = Enumerable.Range(0, 10).Select(it => it.ToString());
                var ie = sin.GetEnumerator();
                while (ie.MoveNext() && numbers.Contains(ie.Current.ToString()))
                {
                    isNumeric |= true;
                    ++i;
                }
                if (isNumeric)
                {
                    sout = sin.Substring(i + 1);
                    sin = sin.Substring(0, i + 1);
                    int.TryParse(sin, out x);
                }
                return false;
            }
        }
