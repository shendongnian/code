    public class Palindrome
    {
        static IList<int> Allowed = new List<int> {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'h',
            'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
            'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '1', '2', '3', '4', '5', '6', '7', '8', '9',
            '0'
        };
        private static int[] GetJustAllowed(string text)
        {
            List<int> characters = new List<int>();
            foreach (var c in text)
                 characters.Add(c | 0x20); 
            
            return characters.Where(c => Allowed.Contains(c)).ToArray();
        }
        public static bool IsPalindrome(string text)
        {
            if(text == null || text.Length == 1)
                 return true;
            int[] chars = GetJustAllowed(text);
            var length = chars.Length;
            while (length > 0)
                if (chars[chars.Length - length] != chars[--length])
                    return false;
            return true;
        }
        public static bool IsPalindrome(int number)
        {
            return IsPalindrome(number.ToString());
        }
        public static bool IsPalindrome(double number)
        {
            return IsPalindrome(number.ToString());
        }
        public static bool IsPalindrome(decimal number)
        {
            return IsPalindrome(number.ToString());
        }
        
    }
