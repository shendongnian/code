    foreach (var item in Session)
    {
        Response.Write("Session Parameter: [");
        Response.Write(item.ToString());
        Response.Write("]<p />Guid Value: [");
        Response.Write(Session[item.ToString()]);        
        Response.Write(']');
    }
