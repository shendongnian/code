        public int NaturalCompare(string x, string y)
        {
            string[] x1, y1;
            x1 = Regex.Split(x.Replace(" ", ""), "([0-9]+)");
            y1 = Regex.Split(y.Replace(" ", ""), "([0-9]+)");
            for (int i = 0; i < x1.Length && i < y1.Length; i++)
            {
                if (!x1[i].Equals(y1[i]))
                {
                    return PartCompare(x1[i], y1[i]);
                }
            }
            return x.CompareTo(y);
        }
        private int PartCompare(string left, string right)
        {
            int x, y;
            if (int.TryParse(left, out x) && int.TryParse(right, out y))
                return x.CompareTo(y);
            return left.CompareTo(right);
        }
