        protected static bool CompareValues(string a, int b)
        {
            return CompareValues(a, b, "1", 0);
        }
        protected static bool CompareValues(string a, int b, string c, int d)
        {
            return CompareValues(a, b, c, d, "1", 0);
        }
        protected static bool CompareValues(string a, int b, string c, int d, string e, int f)
        {
            return ((int.Parse(a) > b || int.Parse(c) > d) && int.Parse(e) > f);
        }
