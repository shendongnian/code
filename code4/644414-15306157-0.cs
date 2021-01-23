    StringBuilder sb = new StringBuilder();
    foreach (var item in Session)
    {
        sb.Append("Session Parameter: [");
        sb.Append(item.ToString());
        sb.Append("]<p />Guid Value: [");
        sb.Append(Session[item.ToString()]);        
        sb.Append(']');
    }
    Response.Write(sb.ToString());
