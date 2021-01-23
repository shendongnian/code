    StringBuilder builder = new StringBuilder(299 * 4); // Or whatever
    for (int i = 0; i < 299; i += 2)
    {
        builder.Append(IntToHex(buffer[i]));
    }
    string combined = builder.ToString();
