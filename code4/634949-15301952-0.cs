    // Copyright (c) 2007 James Newton-King    
    namespace Demo
        {
            using System.Globalization;
            using System.IO;
            using System.Text;
        
            public class JsonHelper
            {
                public static string ToJson(string value, char delimiter = '"', bool appendDelimiters = true)
                {
                    if (string.IsNullOrEmpty(value))
                        return value;
        
                    StringBuilder sb = new StringBuilder(value.Length);
                    using (StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture))
                    {
                        WriteEscapedString(sw, value, delimiter, appendDelimiters);
                        return sw.ToString();
                    }
                }
        
                private static void WriteEscapedString(TextWriter writer, string s, char delimiter, bool appendDelimiters)
                {
                    // leading delimiter
                    if (appendDelimiters)
                        writer.Write(delimiter);
        
                    if (s != null)
                    {
                        char[] chars = null;
                        int lastWritePosition = 0;
        
                        for (int i = 0; i < s.Length; i++)
                        {
                            var c = s[i];
        
                            // don't escape standard text/numbers except '\' and the text delimiter
                            if (c >= ' ' && c < 128 && c != '\\' && c != delimiter)
                                continue;
        
                            string escapedValue;
        
                            switch (c)
                            {
                                case '\t': escapedValue = @"\t"; break;
                                case '\n': escapedValue = @"\n"; break;
                                case '\r': escapedValue = @"\r"; break;
                                case '\f': escapedValue = @"\f"; break;
                                case '\b': escapedValue = @"\b"; break;
                                case '\\': escapedValue = @"\\"; break;
                                case '\u0085': escapedValue = @"\u0085"; break; // Next Line
                                case '\u2028': escapedValue = @"\u2028"; break; // Line Separator
                                case '\u2029': escapedValue = @"\u2029"; break; // Paragraph Separator
                                case '\'': escapedValue = @"\'"; break;
                                case '"': escapedValue = "\\\""; break;
                                default: escapedValue = (c <= '\u001f') ? ToUnicode(c) : null; break;
                            }
        
                            if (escapedValue == null)
                                continue;
        
                            if (i > lastWritePosition)
                            {
                                if (chars == null)
                                    chars = s.ToCharArray();
        
                                // write unchanged chars before writing escaped text
                                writer.Write(chars, lastWritePosition, i - lastWritePosition);
                            }
        
                            lastWritePosition = i + 1;
                            writer.Write(escapedValue);
                        }
        
                        if (lastWritePosition == 0)
                            // no escaped text, write entire string
                            writer.Write(s);
                        else
                        {
                            if (chars == null)
                                chars = s.ToCharArray();
        
                            // write remaining text
                            writer.Write(chars, lastWritePosition, s.Length - lastWritePosition);
                        }
                    }
        
                    // trailing delimiter
                    if (appendDelimiters)
                        writer.Write(delimiter);
                }
        
                private static string ToUnicode(char c)
                {
                    char h1 = ToHex((c >> 12) & '\x000f');
                    char h2 = ToHex((c >> 8) & '\x000f');
                    char h3 = ToHex((c >> 4) & '\x000f');
                    char h4 = ToHex(c & '\x000f');
        
                    return new string(new[] { '\\', 'u', h1, h2, h3, h4 });
                }
        
                private static char ToHex(int n)
                {
                    if (n <= 9)
                        return (char)(n + 48);
                    return 
                        (char)((n - 10) + 97);
                }
                
            }
        }
