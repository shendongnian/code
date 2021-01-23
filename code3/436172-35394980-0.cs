    public static  bool IsPalindrome(string word)
            {
                //first reverse the string
                string reversedString = new string(word.Reverse().ToArray());
                return string.Compare(word, reversedString) == 0 ? true : false;
            }
