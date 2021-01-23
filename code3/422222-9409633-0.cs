    string input = @"Welcome to home | %brand %productName";
                string pattern = @"%\S+";
                var matches = Regex.Matches(input, pattern);
                string result = string.Empty;
                for (int i = 0; i < matches.Count; i++)
                {
                    result += "match " + i + ",value:" + matches[i].Value + "\n";
                }
                Console.WriteLine(result);
