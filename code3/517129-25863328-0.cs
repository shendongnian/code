    public static string RootURL {
	get {
		var _with1 = System.Web.HttpContext.Current.Request;
		return _with1.Url.Scheme + "://" + _with1.Url.Host + _with1.ApplicationPath;
	}
