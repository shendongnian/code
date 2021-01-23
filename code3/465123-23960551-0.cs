    public static List<string> WordWrap(string input, int maxCharacters)
        {
            List<string> lines = new List<string>();
            if (!input.Contains(" ") && !input.Contains("\n"))
            {
                int start = 0;
                while (start < input.Length)
                {
                    lines.Add(input.Substring(start, Math.Min(maxCharacters, input.Length - start)));
                    start += maxCharacters;
                }
            }
            else
            {
                string[] paragraphs = input.Split('\n');
                foreach (string paragraph in paragraphs)
                {
                    string[] words = paragraph.Split(' ');
                    string line = "";
                    foreach (string word in words)
                    {
                        if ((line + word).Length > maxCharacters)
                        {
                            lines.Add(line.Trim());
                            line = "";
                        }
    
                        line += string.Format("{0} ", word);
                    }
    
                    if (line.Length > 0)
                    {
                        lines.Add(line.Trim());
                    }
                }
            }
            return lines;
        }
