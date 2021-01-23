    public static string stringToISO8859str(string textToConvert)
            {
                Encoding iso8859 = Encoding.GetEncoding("iso-8859-1");
                Encoding unicode = Encoding.Unicode;
                byte[] srcTextBytes = iso8859.GetBytes(textToConvert);
                byte[] destTextBytes = Encoding.Convert(iso8859, unicode, srcTextBytes);
                char[] destChars = new char[unicode.GetCharCount(destTextBytes, 0, destTextBytes.Length)];
                unicode.GetChars(destTextBytes, 0, destTextBytes.Length, destChars, 0);
                StringBuilder result = new StringBuilder(textToConvert.Length + (int)(textToConvert.Length * 0.1));
                foreach (char c in destChars)
                {
                    int value = Convert.ToInt32(c);
                    if (value == 34)
                        result.AppendFormat("&quot;");
                    else if (value == 38)
                        result.AppendFormat("&amp;");
                    else if (value == 39)
                        result.AppendFormat("&apos;");
                    else if (value == 60)
                        result.AppendFormat("&lt;");
                    else if (value == 62)
                        result.AppendFormat("&gt;");
                    else
                        result.Append(c);
                }
                return result.ToString();            
            }
