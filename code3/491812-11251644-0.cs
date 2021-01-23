    StringBuilder sb = new StringBuilder();
    
        while (sdr.Read())
        {
           sb.Append("Value");
           ....
        }
    
    if(sb.Length > 0)
    {
    sb.Remove(sb.Length - 1, 1)
    }
    var result = sb.ToString();
