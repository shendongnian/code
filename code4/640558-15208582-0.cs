        private static void Main(string[] args)
        {
            string testLines = "SomeCommand(34,32)\n" +
                               "SomeCommand(1)\n" +
                               "GoTo(5)\n" +
                               "This(\"Will\",\"Be\",\"Skipped\")\n" +
                               "Destination(\"OfTheGoToKeyWord\")";
            Regex r = new Regex(
                "^(?<cmd>\\w+)[(](?<params>\\S+)[)]", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            List<string> lines = testLines.Split('\n').ToList();
            int i = 0;
            while (i < lines.Count)
            {
                try
                {
                    var input = lines[i];
                    var matches = r.Split(input);
                    if (matches[1].Equals("GoTo"))
                    {
                        i = testLines.IndexOf(input);
                    }
                    else
                    {
                        i++;
                    }
                }
                catch (Exception)
                {
                }
            }
