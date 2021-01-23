    @using umbraco.MacroEngines
    @using umbraco.NodeFactory;
    @{
    var root = Model;
    var links = root.link;
    if (links == null)
    {
        return;
    }
    foreach(var item in links)
    {
        DynamicNode linkNode = Model.NodeById(@item.link);
        Response.Redirect(@linkNode.Url);
        break;
    }
    }
