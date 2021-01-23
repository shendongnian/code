    string ParseWeirdFormat(string input)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < input.Length; i += 2)
        {
            string hex = input.Substring(i, 2);
            int value = Convert.ToInt32(hex, 16);
            char c = (char)value;
            sb.Append(c);
        }
        return sb.ToString();
    }
