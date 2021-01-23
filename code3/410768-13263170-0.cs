    private static string ExpandBrackets(string Format)
        {
            int maxLevel = CountNesting(Format);
            for (int currentLevel = maxLevel; currentLevel > 0; currentLevel--)
            {
                string group = string.Empty;
                int repeat = 0;
                int level = 0;
                int start = 0;
                int end = 0;
                for (int i = 0; i < Format.Length; i++)
                    switch (Format[i])
                    {
                        case '(':
                            level++;
                            if (level == currentLevel)
                            {
                                // Isolate the number of repeats if any
                                for (int j = i - 1; j >= 0; j--)
                                {
                                    char c = Format[j];
                                    if (c == ',')
                                    {
                                        start = j + 1;
                                        break;
                                    }
                                    if (char.IsDigit(c))
                                        repeat = int.Parse(c + (repeat != 0 ? repeat.ToString() : string.Empty));
                                    else
                                        throw new Exception("Non-numeric character " + c + " found in front of the brackets");
                                }
                                if (repeat == 0)
                                    repeat = 1;
                                // Isolate the format group
                                for (int j = i + 1; j < Format.Length; j++)
                                {
                                    char c = Format[j];
                                    if (c == ')')
                                    {
                                        end = j;
                                        break;
                                    }
                                    group += c;
                                }
                                i = end;
                                // Substitute the expanded group for the original group in the format string
                                if (string.IsNullOrEmpty(group))
                                    Format = Format.Remove(start, end - start + 1);
                                else
                                    Format = Format.Remove(start, end - start + 1).Insert(start, RepeatString(group, repeat));
                            }
                            break;
                        case ')':
                            level--;
                            break;
                    }
            }
            return Format;
        }
