        public static bool ElementAtPosContains(this string inputStr, int index, string[] valuesToCheck)
        {
            if (valuesToCheck == null || valuesToCheck.Length == 0)
                return false;
 
            return valuesToCheck.Any(sub => string.CompareOrdinal(inputStr, index, sub, 0, sub.Length) == 0);
        }
