    var list = retrieveList(
        context.Request["SalCode"],
        context.Request["groupKeyword"],
        context.Request["text"]));
    if (!String.IsNullOrEmpty(list))
    {
        context.Response.Write(list);
    }
    else
    {
        context.Response.Write("Missing request parameter.");
    }
