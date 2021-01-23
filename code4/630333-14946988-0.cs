            string input1 = "ThisIsAnInputString";
            StringBuilder builder = new StringBuilder();
            foreach (char c in input1)
            {
                if (Char.IsUpper(c))
                {
                    builder.Append(' ');
                    builder.Append(c);
                }
                else
                {
                    builder.Append(c);
                }
            }
            string output = builder.ToString().Trim();
