            // -- regex for | not preceded by a \
            string input = @"1|2|3|This is a string\|type:1";
            string pattern = @"(?<!\\)[|]";
            string[] substrings = Regex.Split(input, pattern);
            foreach (string match in substrings)
            {
                Console.WriteLine("'{0}'", match);
            }
