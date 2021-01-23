    for(int x = 0; x < list.Count; x++)
    {
        if (x > 0)
            sb.Append(",");
        sb.Append(list[x].Name);
    }
    
    var result = sb.toString();
