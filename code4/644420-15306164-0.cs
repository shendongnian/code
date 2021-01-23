    sb.Append("Session Parameter: [");
    sb.Append(item); // ToString is implicit
    sb.Append("]<p />Guid Value: [");
    sb.Append(Session[item.ToString()]);
    sb.Append("]");
