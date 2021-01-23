        string taxNumber = "1222233333445";           
        char[] aa = taxNumber.ToCharArray();
        List<string> finals = new List<string>();
        string temp = string.Empty;
        for (int i = 0; i < aa.Length; i++)
        {
            if (i == 0)
            {
                temp = aa[i].ToString();
            }
            else
            {
                if (aa[i].ToString() == aa[i - 1].ToString())
                {
                    temp += aa[i];
                }
                else
                {
                    if (temp != string.Empty)
                    {
                        finals.Add(temp);
                        temp = aa[i].ToString();
                    }
                }
                if (i == aa.Length - 1)
                {
                    if (aa[i].ToString() != aa[i - 1].ToString())
                    {
                        temp = aa[i].ToString();
                        finals.Add(temp);
                    }
                    else
                    {
                        finals.Add(temp);
                    }
                }
            }
        }
