    string S="10-3 3";
    char[] chars = S.ToCharArray();
                    for (int j = 0; j < chars.Count(); j++)
                    {
                        if (Char.IsDigit(chars[j]))
                        {
    
                        }
                        else
                        {
                            if (j + 1 < chars.Count())
                            {
                                chars[j] = 'f'; //'f' being  replacing character
                                S = new string(chars);
                            }
                            break;
                        }
                    }
    Output: 10f3 3
