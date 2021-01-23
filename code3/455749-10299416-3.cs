            Regex rx = new Regex("(a)\1"); // or any other word you're looking for.
            int position = 0;
            string text = "aaaaabbbbccccaaa";
            int textLength = text.Length;
            Match m = rx.Match(text, position);
            while (m != null && m.Success)
            {
                Console.WriteLine(m.Index);
                if (m.Index <= textLength)
                {
                    m = rx.Match(text, m.Index + 1);
                }
                else
                {
                    m = null;
                }
            }
            Console.ReadKey();
