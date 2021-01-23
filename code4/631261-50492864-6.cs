    public static Dictionary<string, object> ParseJSON(string json)
    {
        int end;
        return ParseJSON(json, 0, out end);
    }
    private static Dictionary<string, object> ParseJSON(string json, int start, out int end)
    {
        Dictionary<string, object> dict = new Dictionary<string, object>();
        bool escbegin = false;
        bool escend = false;
        bool inquotes = false;
        string key = null;
        int cend;
        StringBuilder sb = new StringBuilder();
        Dictionary<string, object> child = null;
        List<object> arraylist = null;
        Regex regex = new Regex(@"\\u([0-9a-z]{4})", RegexOptions.IgnoreCase);
        int autoKey = 0;
        int subArrayCount = 0;
        List<int> arrayIndexes = new List<int>();
        bool inSingleQuotes = false;
        bool inDoubleQuotes = false;
        for (int i = start; i < json.Length; i++)
        {
            char c = json[i];
            if (c == '\\') escbegin = !escbegin;
            if (!escbegin)
            {
                if (c == '"' && !inSingleQuotes)
                {
                    inDoubleQuotes = !inDoubleQuotes;
                    inquotes = !inquotes;
                    if (!inquotes && arraylist != null)
                    {
                        arraylist.Add(DecodeString(regex, sb.ToString()));
                        sb.Length = 0;
                    }
                    continue;
                }
                else if (c == '\'' && !inDoubleQuotes)
                {
                    inSingleQuotes = !inSingleQuotes;
                    inquotes = !inquotes;
                    if (!inquotes && arraylist != null)
                    {
                        arraylist.Add(DecodeString(regex, sb.ToString()));
                        sb.Length = 0;
                    }
                    continue;
                }
                if (!inquotes)
                {
                    switch (c)
                    {
                        case '{':
                            if (i != start)
                            {
                                child = ParseJSON(json, i, out cend);
                                if (arraylist != null)
                                {
                                    arraylist.Add(child);
                                }
                                else
                                {
                                    dict.Add(key.Trim(), child);
                                    key = null;
                                }
                                i = cend;
                            }
                            continue;
                        case '}':
                            end = i;
                            if (key != null)
                            {
                                if (arraylist != null) dict.Add(key.Trim(), arraylist);
                                else dict.Add(key.Trim(), DecodeString(regex, sb.ToString().Trim()));
                            }
                            return dict;
                        case '[':
                            if (arraylist != null)
                            {
                                List<object> _tempArrayList = arraylist;
                                for (int l = 0; l < subArrayCount; l++)
                                {
                                    if (l == subArrayCount - 1)
                                    {
                                        _tempArrayList.Add(new List<object>());
                                    }
                                    else
                                    {
                                        _tempArrayList = (List<object>)_tempArrayList[arrayIndexes[l]];
                                    }
                                }
                                if (arrayIndexes.Count < subArrayCount)
                                {
                                    arrayIndexes.Add(0);
                                }
                                subArrayCount++;
                            }
                            else
                            {
                                arraylist = new List<object>();
                                subArrayCount++;
                            }
                            continue;
                        case ']':
                            if (key == null)
                            {
                                key = "array" + autoKey.ToString();
                                autoKey++;
                            }
                            if (arraylist != null)
                            {
                                List<object> _tempArrayList = arraylist;
                                for (int l = 0; l < subArrayCount; l++)
                                {
                                    if (l == subArrayCount - 1)
                                    {
                                        if (sb.Length > 0)
                                        {
                                            _tempArrayList.Add(sb.ToString());
                                        }
                                        subArrayCount--;
                                        if (subArrayCount == arrayIndexes.Count)
                                        {
                                            arrayIndexes[arrayIndexes.Count - 1]++;
                                        }
                                        else if (subArrayCount == arrayIndexes.Count - 1)
                                        {
                                            arrayIndexes.RemoveAt(arrayIndexes.Count - 1);
                                            if (arrayIndexes.Count > 0)
                                            {
                                                arrayIndexes[arrayIndexes.Count - 1]++;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        _tempArrayList = (List<object>)_tempArrayList[arrayIndexes[l]];
                                    }
                                }
                                sb.Length = 0;
                            }
                            if (subArrayCount == 0)
                            {
                                dict.Add(key.Trim(), arraylist);
                                arraylist = null;
                                key = null;
                            }
                            continue;
                        case ',':
                            if (arraylist == null && key != null)
                            {
                                dict.Add(key.Trim(), DecodeString(regex, sb.ToString().Trim()));
                                key = null;
                                sb.Length = 0;
                            }
                            if (arraylist != null && sb.Length > 0)
                            {
                                List<object> _tempArrayList = arraylist;
                                for (int l = 0; l < subArrayCount; l++)
                                {
                                    if (l == subArrayCount - 1)
                                    {
                                        _tempArrayList.Add(sb.ToString());
                                    }
                                    else
                                    {
                                        _tempArrayList = (List<object>)_tempArrayList[arrayIndexes[l]];
                                    }
                                }
                                sb.Length = 0;
                            }
                            continue;
                        case ':':
                            key = DecodeString(regex, sb.ToString());
                            sb.Length = 0;
                            continue;
                    }
                }
            }
            sb.Append(c);
            if (escend) escbegin = false;
            if (escbegin) escend = true;
            else escend = false;
        }
        end = json.Length - 1;
        return dict; //shouldn't ever get here unless the JSON is malformed
    }
    private static string DecodeString(Regex regex, string str)
    {
        return Regex.Unescape(regex.Replace(str, match => char.ConvertFromUtf32(Int32.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.HexNumber))));
    }
