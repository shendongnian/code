        private static string FindShortestRepeatingString(string value)
        {
            if (value == null) throw new ArgumentNullException("value", "The value paramter is null.");
            for (int substringLength = 1; substringLength <= value.Length / 2; substringLength++)
                if (IsRepeatingStringOfLength(value, substringLength))
                    return value.Substring(0, substringLength);
            return value;
        }
        private static bool IsRepeatingStringOfLength(string value, int substringLength)
        {
            if (value.Length % substringLength != 0)
                return false;
            int instanceCount = value.Length / substringLength;
            for (int characterCounter = 0; characterCounter < substringLength; characterCounter++)
            {
                char currentChar = value[characterCounter];
                for (int instanceCounter = 1; instanceCounter < instanceCount; instanceCounter++)
                    if (value[instanceCounter * substringLength + characterCounter] != currentChar)
                        return false;
            }
            return true;
        }
