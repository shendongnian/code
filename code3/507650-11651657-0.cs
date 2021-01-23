        public string MatchPair(string input, string item1, string item2)
        {
            var ix1 = input.IndexOf(item1);
            var ix2 = input.IndexOf(item2);
            if ((ix1 != -1) && (ix2 != -1))
            {
                return input;
            }
            if (ix1 == -1)
            {
                return this.CutString(input, ix2, item2);
            }
            if (ix2 == -1)
            {
                return this.CutString(input, ix1, item1);
            }
            return string.Empty;
        }
        public string CutString(string input, int ix, string item)
        {
            string left = input.Substring(0, ix);
            string right = input.Substring(ix + item.Length);
            return left + right;
        }
