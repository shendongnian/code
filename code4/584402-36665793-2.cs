        // Paste this dependencies in your class
        using System;
        using System.Net;
        using System.Linq;
        using System.Reflection;
        using System.Collections;
        using System.Collections.Generic;
		/// <summary>
		/// It prints all cookies in a CookieContainer. Only for testing.
		/// </summary>
		/// <param name="cookieJar">A cookie container</param>
		public void PrintCookies (CookieContainer cookieJar)
		{
			try
			{
				Hashtable table = (Hashtable) cookieJar
                    .GetType().InvokeMember("m_domainTable",
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
						Console.WriteLine(cookieJar.Count+" HTTP COOKIES FOUND:");
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
						Console.WriteLine(cookieJar.Count+" HTTPS COOKIES FOUND:");
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
				Console.WriteLine (e);
			}
		}
