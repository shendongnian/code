    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < lines.Count; i++)
    {
        sb.Append(lines[i]);
        if ((i % 4) == 3)
            sb.AppendLine();
        else
            sb.Append(',');
    }
