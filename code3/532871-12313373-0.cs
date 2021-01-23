            string text = "string with whitespace after last character  ";
            Match m = Regex.Match(text, @"^(.*)(\w{1})\s*$");
            if (m.Success)
            {
                int index = m.Groups[1].Length;
                Console.WriteLine(text[index]);
                Console.WriteLine(index);
            }
            Console.ReadLine();
