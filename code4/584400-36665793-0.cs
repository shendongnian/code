		/// <summary>
		/// It prints all cookies in a CookieContainer. Only for testing.
		/// </summary>
		/// <param name="cookieJar">A cookie container</param>
		public void PrintCookies (CookieContainer cookieJar)
		{
			try
			{
				Console.WriteLine("FOUND: "+cookieJar.Count+" Cookies");
				Hashtable table = (Hashtable) cookieJar.GetType().InvokeMember("m_domainTable",
					BindingFlags.NonPublic |
					BindingFlags.GetField |
					BindingFlags.Instance,
					null,
					cookieJar,
					new object[] {});
				foreach (var key in table.Keys)
				{
					// Look for http cookies.
					if (cookieJar.GetCookies(
						new Uri(string.Format("http://{0}/", key))).Count > 0)
					{
						Console.WriteLine("HTTP COOKIES FOUND:");
						Console.WriteLine("----------------------------------");
						foreach (Cookie cookie in cookieJar.GetCookies(
							new Uri(string.Format("http://{0}/", key))))
						{
							Console.WriteLine(
								"Name = {0} ; Value = {1} ; Domain = {2}", 
								cookie.Name, cookie.Value,cookie.Domain);
						}
					}
					// Look for https cookies
					if (cookieJar.GetCookies(
						new Uri(string.Format("https://{0}/", key))).Count > 0)
					{
						Console.WriteLine("HTTPS COOKIES FOUND:");
						Console.WriteLine("----------------------------------");
						foreach (Cookie cookie in cookieJar.GetCookies(
							new Uri(string.Format("https://{0}/", key))))
						{
							Console.WriteLine(
								"Name = {0} ; Value = {1} ; Domain = {2}", 
								cookie.Name, cookie.Value,cookie.Domain);
						}
					}
				}
			}
			catch(Exception e)
			{
				logger.Warn (e);
			}
		}
