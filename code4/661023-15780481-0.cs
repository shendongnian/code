	public static string ConvertToFullUrl(this string relativeUrl)
	{
		if (!Uri.IsWellFormedUriString(relativeUrl, UriKind.Absolute))
		{
			if (!relativeUrl.StartsWith("/"))
			{
				relativeUrl = relativeUrl.Insert(0, "/");
			}
			if (relativeUrl.StartsWith("~/"))
			{
				relativeUrl = relativeUrl.Substring(1);
			}
			return string.Format(
				"{0}://{1}{2}{3}",
				HttpContext.Current.Request.Url.Scheme,
				HttpContext.Current.Request.Url.Host,
				HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port.ToString(),
				relativeUrl);
		}
		else
		{
			return relativeUrl;
		}
	}
