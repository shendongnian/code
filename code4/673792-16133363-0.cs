    string result = "";
    for (int i = 0; i < s.Length; i++)
    {
        if (i % 2 == 0)
        {
            result += (s[i].ToString()).ToUpper(CultureInfo.InvariantCulture);
        }
        if (i % 2 != 0)
        {
            result += (s[i].ToString()).ToLower();
        }
    }
    textBox2.Text = result;
