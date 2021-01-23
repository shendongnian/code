        public IEnumerable<Char> Ascii2
        {
            get
            {
                return Enumerable.Range((int)'a', 26).Select(i => (char)i);
            }
        }
