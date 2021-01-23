         public static List<string> SplitContent(string input)
        {
            var list = new List<string>();
            var regex = new Regex("\\d*\\%[A-Za-z]*");
            var matches = regex.Matches(input);
            foreach (Match item in matches)
            {
                list.Add(item.Value);
            }
            return list;
        }
