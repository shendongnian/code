    <%@ Import Namespace="Tridion.ContentManager.Publishing"%>
    <%!
    private string ExtraString()
    {
    	return "Something added by the C# template";
    }
    %>
    log.Debug("Executing C# template");
    if (engine.RenderMode == RenderMode.Publish)
    {
    	package.GetByName(Package.OutputName).AppendToStringValue(ExtraString());
    }
