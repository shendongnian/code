                    if (strEachCookParts[j].IndexOf("expires=", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        strPNameAndPValue = strEachCookParts[j];
                        if (strPNameAndPValue != string.Empty)
                        {
                            NameValuePairTemp = strPNameAndPValue.Split('=');
                            if (NameValuePairTemp[1] != string.Empty)
                            {
                                cookTemp.Expires = Convert.ToDateTime(NameValuePairTemp[1]);
                            }
                        }
                        continue;
                    }
