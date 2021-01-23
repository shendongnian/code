                String s = "ThisIsMyTestString";
                StringBuilder result = new StringBuilder();
                result.Append(s[0]);
                for (int i = 1; i < s.Length; i++)
                {
                    if (char.IsUpper(s[i]) )
                        result.Append(' ');
                    result.Append(s[i]);
                }
                s = result.ToString();
