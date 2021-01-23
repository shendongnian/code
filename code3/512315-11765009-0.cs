    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            foreach (string x in EndlessBase64Sequence())
            {
                Console.WriteLine(x);
            }
        }
        
        private static char NextBase36Char(char c)
        {
            if ((c >= '0' && c <= '8') ||
                (c >= 'A' && c <= 'Z'))
            {
                return (char) (c + 1);
            }
            if (c == '9')
            {
                return 'A';
            }
            throw new ArgumentException();
        }
        
        public static IEnumerable<string> EndlessBase64Sequence()
        {
            char[] chars = { '0' };
            
            while (true)
            {
                yield return new string(chars);
                
                // Move to the next one...
                bool done = false;
                for (int position = chars.Length - 1; position >= 0; position--)
                {
                    if (chars[position] == 'Z')
                    {
                        chars[position] = '0';
                    }
                    else
                    {
                        done = true;
                        chars[position] = NextBase36Char(chars[position]);
                        break;
                    }
                }
                // Need to expand?
                if (!done)
                {
                    chars = new char[chars.Length + 1];
                    chars[0] = '1';
                    for (int i = 1; i < chars.Length; i++)
                    {
                        chars[i] = '0';
                    }
                }
            }
        }
    }
