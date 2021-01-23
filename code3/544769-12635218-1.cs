        public static int[] GetInts(this int value)
        {            
            if (value == 0)
                return new int[] { 0 };
            else
            {
                int val = value;
                List<int> values = new List<int>();
                while (Math.Abs(val) >= 1)
                {
                    values.Add(Math.Abs(val % 10));
                    val = val / 10;
                }
                values.Reverse();
                return values.ToArray();
            }
        }
