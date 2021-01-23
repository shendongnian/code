    private static string ExpandBrackets(string Format)
        {
            int maxLevel = CountNesting(Format);
            for (int currentLevel = maxLevel; currentLevel > 0; currentLevel--)
            {
                int level = 0;
                int start = 0;
                int end = 0;
                for (int i = 0; i < Format.Length; i++)
                {
                    char thisChar = Format[i];
                    switch (Format[i])
                    {
                        case '(':
                            level++;
                            if (level == currentLevel)
                            {
                                string group = string.Empty;
                                int repeat = 0;
                                /// Isolate the number of repeats if any
                                /// If there are 0 repeats the set to 1 so group will be replaced by itself with the brackets removed
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
                                /// Isolate the format group
                                /// Parse until the first closing bracket. Level is decremented as this effectively takes us down one level
                                for (int j = i + 1; j < Format.Length; j++)
                                {
                                    char c = Format[j];
                                    if (c == ')')
                                    {
                                        level--;
                                        end = j;
                                        break;
                                    }
                                    group += c;
                                }
                                /// Substitute the expanded group for the original group in the format string
                                /// If the group is empty then just remove it from the string
                                if (string.IsNullOrEmpty(group))
                                {
                                    Format = Format.Remove(start - 1, end - start + 2);
                                    i = start;
                                }
                                else
                                {
                                    string repeatedGroup = RepeatString(group, repeat);
                                    Format = Format.Remove(start, end - start + 1).Insert(start, repeatedGroup);
                                    i = start + repeatedGroup.Length - 1;
                                }
                            }
                            break;
                        case ')':
                            level--;
                            break;
                    }
                }
            }
            return Format;
        }
