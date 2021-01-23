        private static bool CompareStrings(string str1, string str2)
        {
            var ar1 = Regex.Matches(str1, @"[\d%]+").Cast<Match>().Select(m => m.Value).ToArray();
            var ar2 = Regex.Matches(str2, @"[\d%]+").Cast<Match>().Select(m => m.Value).ToArray();
            if (ar1.Length != ar2.Length)
                return false;
            // Check wildcards and numbers
            for (int i = 0; i < ar1.Length; i++)
                if (ar1[i] != ar2[i] && ar1[i] != "%" && ar2[i] != "%")
                    return false;
            // Remove wildcards and numbers to check the other characters
            if (Regex.Replace(str1, @"[\d%]+", String.Empty) != Regex.Replace(str2, @"[\d%]+", String.Empty))
                return false;
           return true;
        }
