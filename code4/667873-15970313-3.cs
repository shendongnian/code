	public static bool ViewExists(string _name, ControllerContext _controller_context)
	{
		ViewEngineResult result = ViewEngines.Engines.FindView(_controller_context, _name, null);
		return (result.View != null);
	}
