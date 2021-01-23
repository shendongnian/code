		public class CookieValueProvider : IValueProvider
		{
			private readonly HttpCookieCollection _cookies;
			public CookieValueProvider(HttpCookieCollection cookies)
			{
				_cookies = cookies;
			}
			public bool ContainsPrefix(string prefix)
			{
				return _cookies.AllKeys.Any(x => x.Contains(prefix));
			}
			public ValueProviderResult GetValue(string key)
			{
				if (_cookies == null)
				{
					return null;
				}
				var val = _cookies[key] == null ? null : _cookies[key].ToString();
				var val = _cookies[key];
				return val != null
						   ? new ValueProviderResult(val, val.ToString(), CultureInfo.CurrentCulture)
						   : null;
			}
		}
		public override IValueProvider GetValueProvider(ControllerContext controllerContext)
		{
			return new CookieValueProvider(controllerContext.HttpContext.Request.Cookies);
		}
	}
