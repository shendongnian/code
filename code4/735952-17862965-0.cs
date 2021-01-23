    private int multiDecCompare(string str1, string str2)
        {
            try
            {
                string[] split1 = str1.Split('.');
                string[] split2 = str2.Split('.');
                if (split1.Length != split2.Length)
                    return -99;
                for (int i = 0; i < split1.Length; i++)
                {
                    if (Int32.Parse(split1[i]) > Int32.Parse(split2[i]))
                        return 1;
                    if (Int32.Parse(split1[i]) < Int32.Parse(split2[i]))
                        return -1;
                }
                return 0;
            }
            catch
            {
                return -99;
            }
        }
