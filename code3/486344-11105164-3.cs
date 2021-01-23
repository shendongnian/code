            string input = "A bgt abc hyi. Abc Ab df h";
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("abc", "cde");
            map.Add("ab df", "de");
            string temp = input;
            foreach (var entry in map)
            {
                string key = entry.Key;
                string value = entry.Value;
                temp = Regex.Replace(temp, key, match =>
                {
                    bool isUpper = char.IsUpper(match.Value[0]);
                    char[] result = value.ToCharArray();
                    result[0] = isUpper
                        ? char.ToUpper(result[0])
                        : char.ToLower(result[0]);
                    return new string(result);
                }, RegexOptions.IgnoreCase);
            }
            label1.Text = temp; // output is A bgt cde hyi. Cde De h
