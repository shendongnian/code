            string a = "aaabbbasdlfjasldfkjalsdkfjaewoasdfj";
            Dictionary<char, int> charCounts = new Dictionary<char, int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (!charCounts.Keys.Contains(a[i]))
                {
                    charCounts[a[i]] = 1;
                }
                else
                {
                    charCounts[a[i]] += 1;
                }
            }
            foreach (char letter in charCounts.Keys.OrderBy(x => x))
            {
                Console.Write(string.Format("{0}{1}", letter, charCounts[letter]));
            }
