    public class Travel2ViewEngine : RazorViewEngine
    {
    	protected BrandNameEnum BrandName;
    	private string[] _newAreaViewLocations = new string[] {
    		"~/Areas/{2}/%1Views/{1}/{0}.cshtml",
    		"~/Areas/{2}/%1Views/{1}/{0}.vbhtml",
    		"~/Areas/{2}/%1Views//Shared/{0}.cshtml",
    		"~/Areas/{2}/%1Views//Shared/{0}.vbhtml"
    	};
    
    	private string[] _newAreaMasterLocations = new string[] {
    		"~/Areas/{2}/%1Views/{1}/{0}.cshtml",
    		"~/Areas/{2}/%1Views/{1}/{0}.vbhtml",
    		"~/Areas/{2}/%1Views/Shared/{0}.cshtml",
    		"~/Areas/{2}/%1Views/Shared/{0}.vbhtml"
    	};
    
    	private string[] _newAreaPartialViewLocations = new string[] {
    		"~/Areas/{2}/%1Views/{1}/{0}.cshtml",
    		"~/Areas/{2}/%1Views/{1}/{0}.vbhtml",
    		"~/Areas/{2}/%1Views/Shared/{0}.cshtml",
    		"~/Areas/{2}/%1Views/Shared/{0}.vbhtml"
    	};
    
    	private string[] _newViewLocations = new string[] {
    		"~/%1Views/{1}/{0}.cshtml",
    		"~/%1Views/{1}/{0}.vbhtml",
    		"~/%1Views/Shared/{0}.cshtml",
    		"~/%1Views/Shared/{0}.vbhtml"
    	};
    
    	private string[] _newMasterLocations = new string[] {
    		"~/%1Views/{1}/{0}.cshtml",
    		"~/%1Views/{1}/{0}.vbhtml",
    		"~/%1Views/Shared/{0}.cshtml",
    		"~/%1Views/Shared/{0}.vbhtml"
    	};
    
    	private string[] _newPartialViewLocations = new string[] {
    		"~/%1Views/{1}/{0}.cshtml",
    		"~/%1Views/{1}/{0}.vbhtml",
    		"~/%1Views/Shared/{0}.cshtml",
    		"~/%1Views/Shared/{0}.vbhtml"
    	};
    
    	public Travel2ViewEngine()
    		: base()
    	{
    		Enum.TryParse<BrandNameEnum>(Travel2.WebUI.Properties.Settings.Default.BrandName, out BrandName);
    
    		AreaViewLocationFormats = AppendLocationFormats(_newAreaViewLocations, AreaViewLocationFormats);
    
    		AreaMasterLocationFormats = AppendLocationFormats(_newAreaMasterLocations, AreaMasterLocationFormats);
    
    		AreaPartialViewLocationFormats = AppendLocationFormats(_newAreaPartialViewLocations, AreaPartialViewLocationFormats);
    
    		ViewLocationFormats = AppendLocationFormats(_newViewLocations, ViewLocationFormats);
    
    		MasterLocationFormats = AppendLocationFormats(_newMasterLocations, MasterLocationFormats);
    
    		PartialViewLocationFormats = AppendLocationFormats(_newPartialViewLocations, PartialViewLocationFormats);
    	}
    
    	private string[] AppendLocationFormats(string[] newLocations, string[] defaultLocations)
    	{
    		List<string> viewLocations = new List<string>();
    		viewLocations.AddRange(newLocations);
    		viewLocations.AddRange(defaultLocations);
    		return viewLocations.ToArray();
    	}
    
    	protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
    	{
    		return base.CreateView(controllerContext, viewPath.Replace("%1", BrandName.ToString()), masterPath);
    	}
    
    	protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
    	{
    		return base.CreatePartialView(controllerContext, partialPath.Replace("%1", BrandName.ToString()));
    	}
    
    	protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
    	{
    		return base.FileExists(controllerContext, virtualPath.Replace("%1", BrandName.ToString()));
    	}
    }
