        public static bool ElementAtPosContains(this string inputStr, int index, string[] valuesToCheck)
        {
            if (valuesToCheck == null)
                return false;
            string s = inputStr.Substring(index, inputStr.Length - index);
            return valuesToCheck.Any(sub => s.StartsWith(sub));
        }
