	public class UrlHelperEx : UrlHelper
	{
		#region Constants
		private const string c_VERSION_FORMAT = "{0}?v={1}";
		#endregion
		#region Initialization
		public UrlHelperEx(RequestContext requestContext)
			: base(requestContext)
		{
		}
		#endregion
		#region Public methods
		public string Content(string contentPath,bool forceupdate=false)
		{
			var content = base.Content(contentPath);
			if (!forceupdate) {
				return content.ToString();
			}
			else
			{ 
				Version version = WebHelper.GetApplicationVersion(this.RequestContext.HttpContext);
				return string.Format(c_VERSION_FORMAT, content
						, version.ToString());
			}
		}
		#endregion  
	}
