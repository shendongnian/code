                for (int i = 0; i < acct[line].Length; i++)
                {
                    if (acct[line][i].ToString() == ":")
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
                }
