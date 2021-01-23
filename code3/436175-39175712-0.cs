        public static bool IsPalindrome(string str) {
            str = new Regex("[^a-zA-Z]").Replace(str, "").ToLower();
            for (int i = 0; i < str.Length; i++)
                if (str[i] != str[str.Length - i - 1])
                    return false;
            return true;
        }
