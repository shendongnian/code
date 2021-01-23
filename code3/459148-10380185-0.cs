    using System;
    public class Test
    {
        public static void Main()
        {            
            string example = "racecar";
            bool isPal = IsBothEndsPalindrome(example, 3);
            Console.WriteLine(isPal);
        }
    
        static bool IsBothEndsPalindrome(string s, int i) {
            while(i-- > 0) {
                if(s[i] != s[s.Length - i - 1]) return false;
             }
             return true;
        }
    }
