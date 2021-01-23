    public static unsafe void HtmlEncode(string value, TextWriter output)
    {
        if (value != null)
        {
            if (output == null)
            {
                throw new ArgumentNullException("output");
            }
            int num = IndexOfHtmlEncodingChars(value, 0);
            if (num == -1)
            {
                output.Write(value);
            }
            else
            {
                int charsRemaining = value.Length - num;
                fixed (char* str = ((char*) value))
                {
                    char* chPtr = str;
                    char* pch = chPtr;
                    while (num-- > 0)
                    {
                        pch++;
                        output.Write(pch[0]);
                    }
                    while (charsRemaining > 0)
                    {
                        char ch = pch[0];
                        if (ch <= '>')
                        {
                            switch (ch)
                            {
                                case '&':
                                    output.Write("&amp;");
                                    goto Label_0177;
    
                                case '\'':
                                    output.Write("&#39;");
                                    goto Label_0177;
    
                                case '"':
                                    output.Write("&quot;");
                                    goto Label_0177;
    
                                case '<':
                                    output.Write("&lt;");
                                    goto Label_0177;
    
                                case '>':
                                    output.Write("&gt;");
                                    goto Label_0177;
                            }
                            output.Write(ch);
                        }
                        else
                        {
                            int num3 = -1;
                            if ((ch >= '\x00a0') && (ch < 'Ā'))
                            {
                                num3 = ch;
                            }
                            else if ((_htmlEncodeConformance == UnicodeEncodingConformance.Strict) && char.IsSurrogate(ch))
                            {
                                int num4 = GetNextUnicodeScalarValueFromUtf16Surrogate(ref pch, ref charsRemaining);
                                if (num4 >= 0x10000)
                                {
                                    num3 = num4;
                                }
                                else
                                {
                                    ch = (char) num4;
                                }
                            }
                            if (num3 >= 0)
                            {
                                output.Write("&#");
                                output.Write(num3.ToString(NumberFormatInfo.InvariantInfo));
                                output.Write(';');
                            }
                            else
                            {
                                output.Write(ch);
                            }
                        }
                    Label_0177:
                        charsRemaining--;
                        pch++;
                    }
                }
            }
        }
    }
