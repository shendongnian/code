	using System;
	using System.Collections.Generic;
	using System.Net;
	namespace AG.WebHelpers
	{
		static public class ExtensionMethods
		{
			static public void FixCookies(this HttpWebRequest request, HttpWebResponse response)
			{
				for (int i = 0; i < response.Headers.Count; i++)
				{
					string name = response.Headers.GetKey(i);
					if (name != "Set-Cookie")
						continue;
					string value = response.Headers.Get(i);
					var cookieCollection = ParseCookieString(value, () => request.Host.Split(':')[0]);
					response.Cookies.Add(cookieCollection);
				}
			}
			static private CookieCollection ParseCookieString(string cookieString, Func<string> getCookieDomainIfItIsMissingInCookie)
			{
				bool secure = false;
				bool httpOnly = false;
				string domainFromCookie = null;
				string path = null;
				string expiresString = null;
				Dictionary<string, string> cookiesValues = new Dictionary<string, string>();
				var cookieValuePairsStrings = cookieString.Split(';');
				foreach(string cookieValuePairString in cookieValuePairsStrings)
				{
					var pairArr = cookieValuePairString.Split('=');
					int pairArrLength = pairArr.Length;
					for (int i = 0; i < pairArrLength; i++)
					{
						pairArr[i] = pairArr[i].Trim();
					}
					string propertyName = pairArr[0];
					if (pairArrLength == 1)
					{
						if (propertyName.Equals("httponly", StringComparison.OrdinalIgnoreCase))
							httpOnly = true;
						else if (propertyName.Equals("secure", StringComparison.OrdinalIgnoreCase))
							secure = true;
						else
							throw new InvalidOperationException(string.Format("Unknown cookie property \"{0}\". All cookie is \"{1}\"", propertyName, cookieString));
						continue;
					}
					string propertyValue = pairArr[1];
					if (propertyName.Equals("expires", StringComparison.OrdinalIgnoreCase))
						expiresString = propertyValue;
					else if (propertyName.Equals("domain", StringComparison.OrdinalIgnoreCase))
						domainFromCookie = propertyValue;
					else if (propertyName.Equals("path", StringComparison.OrdinalIgnoreCase))
						path = propertyValue;
					else
						cookiesValues.Add(propertyName, propertyValue);
				}
				DateTime expiresDateTime;
				if (expiresString != null)
				{
					expiresDateTime = DateTime.Parse(expiresString);
				}
				else
				{
					expiresDateTime = DateTime.MinValue;
				}
				if (string.IsNullOrEmpty(domainFromCookie))
				{
					domainFromCookie = getCookieDomainIfItIsMissingInCookie();
				}
				CookieCollection cookieCollection = new CookieCollection();
				foreach (var pair in cookiesValues)
				{
					Cookie cookie = new Cookie(pair.Key, pair.Value, path, domainFromCookie);
					cookie.Secure = secure;
					cookie.HttpOnly = httpOnly;
					cookie.Expires = expiresDateTime;
					cookieCollection.Add(cookie);
				}
				return cookieCollection;
			}
		}
	}
