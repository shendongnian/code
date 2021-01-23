    char[] chars = "ABC".ToCharArray();
    for (int i = 0; i < chars.Length; i++)
    {
        chars[i] += (char)2;
    }
    string result = new string(chars);
    //    result == "CDE"
