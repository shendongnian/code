                for (int line = 0; line < acct.Length; line++)
                {
                    int i = 0;
                    foreach (char c in acct[line])
                    {
                        if (c.ToString() == ":")
                        {
                            onPass = true;
                        }
                        else
                        {
                            if (!onPass)
                                user += acct[line][i];
                            else
                                pass += acct[line][i];
                        }
                        i++;
                    }
                }
