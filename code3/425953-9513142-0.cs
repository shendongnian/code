    string text = "a b c d e f";
            List<String> dbStrings = new List<string>();
            dbStrings.AddRange(new string[] { "a", "b", "c" });
            foreach (string dbString in dbStrings) {
                string pattern = @"(?<=^|\s)" + dbString + @"(?=\s|$)";
                if (Regex.IsMatch(text, pattern)) {
                    Console.WriteLine(dbString);
                }
            }
