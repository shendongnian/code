            string a = "aaabbbasdlfjasldfkjalsdkfjaewoasdfj";
           
            //store character counts in a dictionary 
            Dictionary<char, int> charCounts = new Dictionary<char, int>();
            //iterate through string and place counts in dictionary
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
            //output sorted list
            foreach (char letter in charCounts.Keys.OrderBy(x => x))
            {
                Console.Write(string.Format("{0}{1}", letter, charCounts[letter]));
            }
