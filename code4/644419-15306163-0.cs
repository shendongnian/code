    foreach (var item in Session)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Session Parameter: [");
        sb.Append(item.ToString());
        sb.Append("]<p />Guid Value: [");
        sb.Append(Session[item.ToString()]);
        sb.Append("]");
    
        Response.Write(sb.ToString());
    }
