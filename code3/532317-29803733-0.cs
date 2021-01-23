		public static string RequestFQ(this System.Web.UI.Page p, string key, string valueForNullResult = "?")
		{	string v = p.Request.Form[key] ?? p.Request.QueryString[key];
			if (v == valueForNullResult) { v = null; }
			return v;
		} // public string RequestFQ(this System.Web.UI.Page p, string key, string valueForNullResult = "?")
