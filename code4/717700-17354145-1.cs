    public static string HtmlDecode(string html)
    {
        if (html == null)
        {
            return null;
        }
        if (html.IndexOf('&') < 0)
        {
            return html;
        }
        StringBuilder sb = new StringBuilder();
        StringWriter writer = new StringWriter(sb, CultureInfo.InvariantCulture);
        int length = html.Length;
        for (int i = 0; i < length; i++)
        {
            char ch = html[i];
            if (ch == '&')
            {
                int num3 = html.IndexOfAny(s_entityEndingChars, i + 1);
                if ((num3 > 0) && (html[num3] == ';'))
                {
                    string entity = html.Substring(i + 1, (num3 - i) - 1);
                    if ((entity.Length > 1) && (entity[0] == '#'))
                    {
                        try
                        {
                            if ((entity[1] == 'x') || (entity[1] == 'X'))
                            {
                                ch = (char) int.Parse(entity.Substring(2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                ch = (char) int.Parse(entity.Substring(1), CultureInfo.InvariantCulture);
                            }
                            i = num3;
                        }
                        catch (FormatException)
                        {
                            i++;
                        }
                        catch (ArgumentException)
                        {
                            i++;
                        }
                    }
                    else
                    {
                        i = num3;
                        char ch2 = HtmlEntities.Lookup(entity);
                        if (ch2 != '\0')
                        {
                            ch = ch2;
                        }
                        else
                        {
                            writer.Write('&');
                            writer.Write(entity);
                            writer.Write(';');
                            continue;
                        }
                    }
                }
            }
            writer.Write(ch);
        }
        return sb.ToString();
    }
    
     
