    using System;
    
    class Program
    {
        /// <summary>
        /// Determines whether the string is a palindrome.
        /// </summary>
        public static bool IsPalindrome(string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
    
                // Scan forward for a while invalid.
                while (!char.IsLetterOrDigit(a))
                {
                    min++;
                    if (min > max)
                    {
                        return true;
                    }
                    a = value[min];
                }
    
                // Scan backward for b while invalid.
                while (!char.IsLetterOrDigit(b))
                {
                    max--;
                    if (min > max)
                    {
                        return true;
                    }
                    b = value[max];
                }
    
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }
    
        static void Main()
        {
            string[] array =
            {
                "A man, a plan, a canal: Panama.",
                "A Toyota. Race fast, safe car. A Toyota.",
                "Cigar? Toss it in a can. It is so tragic.",
                "Dammit, I'm mad!",
                "Delia saw I was ailed.",
                "Desserts, I stressed!",
                "Draw, O coward!",
                "Lepers repel.",
                "Live not on evil.",
                "Lonely Tylenol.",
                "Murder for a jar of red rum.",
                "Never odd or even.",
                "No lemon, no melon.",
                "Senile felines.",
                "So many dynamos!",
                "Step on no pets.",
                "Was it a car or a cat I saw?",
    
                "Dot Net Perls is not a palindrome.",
                "Why are you reading this?",
                "This article is not useful.",
                "...",
                "...Test"
            };
    
            foreach (string value in array)
            {
                Console.WriteLine("{0} = {1}", value, IsPalindrome(value));
            }
        }
    }
