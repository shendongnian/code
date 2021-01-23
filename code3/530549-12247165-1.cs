    var sb = new StringBuilder();
    for (int i = 0; i < 299; i += 2)
        {
            sb.Append(IntToHex(buffer[i]));
        }
    variable1 = sb.ToString();
