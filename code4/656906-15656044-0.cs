    string input = "12345678";
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < input.Length; i++)
    {
        if (i % 3 == 0)
            sb.Append(',');
        sb.Append(input[i]);
    }
    string formatted = sb.ToString();
