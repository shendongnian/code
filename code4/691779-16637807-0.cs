        static void Main(string[] args)
        {
            string test = ".white> TD { color: white;box-shadow: 0px 0px 3px white, inset 0px 0px 5px black; white-space:pre-wrap; }";
            Console.WriteLine("Before: " + test);
            test = replaceIfNotFollowedBy(test, "white", "black", "-space");
            Console.WriteLine("After: " + test);
            Console.ReadLine();
        }
        static string replaceIfNotFollowedBy(string text, string replace, string replacement, string notAfter)
        {
            int index = text.IndexOf(replace, 0);
            while (index != -1)
            {
                if (!(index + notAfter.Length <= text.Length &&
                    text.Substring(index + replace.Length, notAfter.Length) == notAfter))
                {
                    text = text.Remove(index, replace.Length);
                    text = text.Insert(index, replacement);
                }
                index = text.IndexOf(replace, index + notAfter.Length + 1);
            }
            return text;
        }
