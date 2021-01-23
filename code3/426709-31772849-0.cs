    private string JavaScriptStringDecode(string value, bool removeDoubleQuotes)
                {
                    StringBuilder b = new StringBuilder();
                    int startIndex = 0;
                    int count = 0;
                    for (int i = 0; i < value.Length; i++)
                    {
                        var c = value[i];
                        if (c == '\\')
                        {
                            if (count > 0)
                            {
                                b.Append(value, startIndex, count);
                                count = 0;
                            }
    
                            if (i < value.Length - 1)
                            {
                                var c1 = value[i + 1];
                                bool ignore = false;
                                char charToAppend;
                                switch (c1)
                                {
                                    case 'r':
                                        charToAppend = '\r';
                                        break;
                                    case 't':
                                        charToAppend = '\t';
                                        break;
                                    case 'n':
                                        charToAppend = '\n';
                                        break;
                                    case 'b':
                                        charToAppend = '\b';
                                        break;
                                    case 'f':
                                        charToAppend = '\f';
                                        break;
                                    case '\\':
                                        charToAppend = '\\';
                                        break;
                                    case '\'':
                                        charToAppend = '\'';
                                        break;
                                    case '\"':
                                        charToAppend = '\"';
                                        break;
                                    case 'u':
                                    case 'U':
                                        if (i < value.Length - 5)
                                        {
                                            var style = NumberStyles.HexNumber;
                                            var cult = CultureInfo.InvariantCulture;
                                            int u;
    
                                            if (Int32.TryParse(value.Substring(i + 2, 4), style, cult, out u))
                                            {
                                                charToAppend = ((char)u);
                                                i += 4;
                                                break;
                                            }
                                        }
                                        charToAppend = '\\';
                                        ignore = true;
                                        break;
                                    default:
                                        charToAppend = '\\';
                                        ignore = true;
    
                                        break;
                                }
                                if (!ignore)
                                {
                                    i++;
                                }
                                startIndex = i + 1;
                                b.Append(charToAppend);
                                continue;
                            }
    
    
                        }
                        count++;
                        
                    }
                    if (count > 0)
                    {
                        b.Append(value, startIndex, count);
                    }
                    if (removeDoubleQuotes)
                    {
                        if (b.Length > 0)
                        {
                            if (b[0] == '"')
                            {
                                b.Remove(0, 1);
                            }
                            if (b[b.Length - 1] == '"')
                            {
                                b.Remove(b.Length - 1, 1);
                            }
                        }
                    }
                    return b.ToString();
                }
