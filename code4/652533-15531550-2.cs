    //handles http://MySite/Submit?method=Crash
    [ActionNameWithParameter(Name = "Submit", ParameterName = "method", ParameterValue = "Crash")]
    public ActionResult SubmitCrash()
    {
      return View();
    }
    
    //handles http://MySite/Submit?method=Bug
    [ActionNameWithParameter(Name = "Submit", ParameterName = "method", ParameterValue = "Bug")]
    public ActionResult SubmitBug()
    {
      return View();
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class ActionNameWithParameterAttribute : ActionNameSelectorAttribute
    {
    	public string Name
    	{
    		get;
    		private set;
    	}
    	public string ParameterName
    	{
    		get;
    		private set;
    	}
    	public string ParameterValue
    	{
    		get;
    		private set;
    	}
    	public ActionNameAttribute(string name, string parameterName, string parameterValue)
    	{
    		if (string.IsNullOrEmpty(name))
    		{
    			throw new ArgumentException(MvcResources.Common_NullOrEmpty, "name");
    		}
    		this.Name = name;
    		this.ParameterName = parameterName;
    		this.ParameterValue = parameterValue;
    	}
    	public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
    	{
    		return string.Equals(actionName, this.Name, StringComparison.OrdinalIgnoreCase)
    			&& string.Equals(controllerContext.HttpContext.Request.QueryString.Get(ParameterName)
    				, this.ParameterValue
    				, StringComparison.OrdinalIgnoreCase);
    	}
    }
