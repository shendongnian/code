      public static string IncrementString(this string input)
        {
            string rtn = "A";
            if (!string.IsNullOrWhiteSpace(input))
            {
                bool prependNew = false;
                var sb = new StringBuilder(input.ToUpper());
                for (int i = (sb.Length - 1); i >= 0; i--)
                {
                    if (i == sb.Length - 1)
                    {
                        var nextChar = Convert.ToUInt16(sb[i]) + 1;
                        if (nextChar > 90)
                        {
                            sb[i] = 'A';
                            if ((i - 1) >= 0)
                            {
                                sb[i - 1] = (char)(Convert.ToUInt16(sb[i - 1]) + 1);
                            }
                            else
                            {
                                prependNew = true;
                            }
                        }
                        else
                        {
                            sb[i] = (char)(nextChar);
                            break;
                        }
                    }
                    else
                    {
                        if (Convert.ToUInt16(sb[i]) > 90)
                        {
                            sb[i] = 'A';
                            if ((i - 1) >= 0)
                            {
                                sb[i - 1] = (char)(Convert.ToUInt16(sb[i - 1]) + 1);
                            }
                            else
                            {
                                prependNew = true;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                rtn = sb.ToString();
                if (prependNew)
                {
                    rtn = "A" + rtn;
                }
            }
            return rtn.ToUpper();
        }
