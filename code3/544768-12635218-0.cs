        public static int[] GetInts(this int value)
        {            
            int val = value;
            List<int> values = new List<int>();
            while (val >= 1)
            {
                values.Add(val % 10);
                val = val / 10;
            }
            values.Reverse();
            return values.ToArray();
        }
