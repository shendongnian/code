    public static void HtmlDecode(string value, TextWriter output)
    {
        if (value != null)
        {
            if (output == null)
            {
                throw new ArgumentNullException("output");
            }
            if (!StringRequiresHtmlDecoding(value))
            {
                output.Write(value);
            }
            else
            {
                int length = value.Length;
                for (int i = 0; i < length; i++)
                {
                    bool flag;
                    uint num4;
                    char ch = value[i];
                    if (ch != '&')
                    {
                        goto Label_01B6;
                    }
                    int num3 = value.IndexOfAny(_htmlEntityEndingChars, i + 1);
                    if ((num3 <= 0) || (value[num3] != ';'))
                    {
                        goto Label_01B6;
                    }
                    string entity = value.Substring(i + 1, (num3 - i) - 1);
                    if ((entity.Length <= 1) || (entity[0] != '#'))
                    {
                        goto Label_0188;
                    }
                    if ((entity[1] == 'x') || (entity[1] == 'X'))
                    {
                        flag = uint.TryParse(entity.Substring(2), NumberStyles.AllowHexSpecifier, NumberFormatInfo.InvariantInfo, out num4);
                    }
                    else
                    {
                        flag = uint.TryParse(entity.Substring(1), NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out num4);
                    }
                    if (flag)
                    {
                        switch (_htmlDecodeConformance)
                        {
                            case UnicodeDecodingConformance.Strict:
                                flag = (num4 < 0xd800) || ((0xdfff < num4) && (num4 <= 0x10ffff));
                                goto Label_0151;
    
                            case UnicodeDecodingConformance.Compat:
                                flag = (0 < num4) && (num4 <= 0xffff);
                                goto Label_0151;
    
                            case UnicodeDecodingConformance.Loose:
                                flag = num4 <= 0x10ffff;
                                goto Label_0151;
                        }
                        flag = false;
                    }
                Label_0151:
                    if (!flag)
                    {
                        goto Label_01B6;
                    }
                    if (num4 <= 0xffff)
                    {
                        output.Write((char) num4);
                    }
                    else
                    {
                        char ch2;
                        char ch3;
                        ConvertSmpToUtf16(num4, out ch2, out ch3);
                        output.Write(ch2);
                        output.Write(ch3);
                    }
                    i = num3;
                    goto Label_01BD;
                Label_0188:
                    i = num3;
                    char ch4 = HtmlEntities.Lookup(entity);
                    if (ch4 != '\0')
                    {
                        ch = ch4;
                    }
                    else
                    {
                        output.Write('&');
                        output.Write(entity);
                        output.Write(';');
                        goto Label_01BD;
                    }
                Label_01B6:
                    output.Write(ch);
                Label_01BD:;
                }
            }
        }
    }
