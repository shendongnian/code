        public static double CompareStrings(string strA, string strB)
        {
            List<string> setA = new List<string>();
            List<string> setB = new List<string>();
            for (int i = 0; i < strA.Length - 1; ++i)
                setA.Add(strA.Substring(i, 2));
            for (int i = 0; i < strB.Length - 1; ++i)
                setB.Add(strB.Substring(i, 2));
            var intersection = setA.Intersect(setB, StringComparer.InvariantCultureIgnoreCase);
            return (2.0 * intersection.Count()) / (setA.Count + setB.Count);
        }
