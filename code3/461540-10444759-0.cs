            List<string> invalidLetters = new List<string>();
            var txt = new { Text = "Stack Overflow" };
            string letter = "o";
            string input = txt.Text;
            if (!Regex.IsMatch(input, letter, RegexOptions.IgnoreCase))
            {
                invalidLetters.Add(letter);
                Console.WriteLine("Letter " + letter + " does not appear in the string.");
            }
            else
            {
                MatchCollection coll = Regex.Matches(input, letter, RegexOptions.IgnoreCase);
                Console.WriteLine("Letter " + letter + " appears in the following locations:");
                foreach (Match m in coll)
                {
                    Console.WriteLine(m.Index);
                }
            }
            Console.ReadLine();
