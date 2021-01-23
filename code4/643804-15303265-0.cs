        public static string BreakLine(string text, int maxCharsInLine)
        {
            int charsInLine = 0;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (char.IsWhiteSpace(c) || charsInLine >= maxCharsInLine)
                {
                    builder.AppendLine();
                    charsInLine = 0;
                }
                else 
                {
                    builder.Append(c);
                    charsInLine++;                    
                }
            }
            return builder.ToString();
        }
