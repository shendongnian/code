        public List<string> ParseCsvRow(char delimiter, string input)
        {
            List<string> result = new List<string>();
            string step = "";
            bool escaped = false;
            StringBuilder stringBuilder = new StringBuilder();
            int position = -1;
            do
            {
                if (++position >= input.Length)
                {
                    result.Add(stringBuilder.ToString());
                    stringBuilder = null;
                    break;
                }
                step = input.Substring(position, 1);
                switch (step)
                {
                    case "\"":
                        if (stringBuilder.Length == 0 && !escaped)
                        {
                            escaped = true;
                            continue;
                        }
                        if (position + 1 < input.Length)
                            step = input.Substring(++position, 1);
                        else
                            step = "";
                        if (step == "\"")
                        {
                            stringBuilder.Append("\"");
                            continue;
                        }
                        if (step.Equals(delimiter.ToString()) && escaped)
                        {
                            result.Add(stringBuilder.ToString());
                            stringBuilder.Clear();
                            escaped = false;
                            continue;
                        }
                        break;
                    default:
                        if (step.Equals(delimiter.ToString()) && !escaped)
                        {
                            result.Add(stringBuilder.ToString());
                            stringBuilder.Clear();
                            continue;
                        }
                        stringBuilder.Append(step);
                        continue;
                }
            } while (true);
            return result;
        }
