    int i = 0;
    int len = 0;
    for (int j = 0; j < s.Length; j++)
        if (s[j] != '0')
            len++;
    int[] result = new int[len];
    int index = 0;
    while (i < s.Length)
    {
        if (i < s.Length - 1 && int.Parse(s[i + 1].ToString()) == 0)
        {
            result[index++] = int.Parse(s[i].ToString()) * 10;
            i += 2;
        }
        else
        {
            result[index++] = int.Parse(s[i].ToString());
            i++;
        }
    }
    return result;
