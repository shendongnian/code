        public static bool In(this string str, params string[] p)
        {
            foreach (var s in p)
            {
                if (str.Contains(s)) return true;
            }
            return false;
        }
