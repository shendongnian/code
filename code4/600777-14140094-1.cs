	using System;
	using System.IO;
	using System.Net;
	using System.Text;
	namespace XYZ
	{
		public class Crawler
		{
			const string Url = "https://www.sefaz.rr.gov.br/sintegra/servlet/hwsintco";
			public void Crawl()
			{
				var cookieContainer = new CookieContainer();
				/* initial GET Request */
				var getRequest = (HttpWebRequest)WebRequest.Create(Url);
				getRequest.CookieContainer = cookieContainer;
				ReadResponse(getRequest); // nothing to do with this, because captcha is f#@%ing dumb :)
				/* POST Request */
				var postRequest = (HttpWebRequest)WebRequest.Create(Url);
				postRequest.AllowAutoRedirect = false; // we'll do the redirect manually; .NET does it badly
				postRequest.CookieContainer = cookieContainer;
				postRequest.Method = "POST";
				postRequest.ContentType = "application/x-www-form-urlencoded";
				var postParameters =
					"_EventName=E%27CONFIRMAR%27.&_EventGridId=&_EventRowId=&_MSG=&_CONINSEST=&" +
					"_CONINSESTG=08775724000119&cfield=much&_VALIDATIONRESULT=1&BUTTON1=Confirmar&" +
					"sCallerURL=";
				var bytes = Encoding.UTF8.GetBytes(postParameters);
				postRequest.ContentLength = bytes.Length;
				using (var requestStream = postRequest.GetRequestStream())
					requestStream.Write(bytes, 0, bytes.Length);
				var webResponse = postRequest.GetResponse();
				ReadResponse(postRequest); // not interested in this either
				var redirectLocation = webResponse.Headers[HttpResponseHeader.Location];
				var finalGetRequest = (HttpWebRequest)WebRequest.Create(redirectLocation);
				/* Apply fix for the cookie */
				FixMisplacedCookie(cookieContainer);
				/* do the final request using the correct cookies. */
				finalGetRequest.CookieContainer = cookieContainer;
				var responseText = ReadResponse(finalGetRequest);
				Console.WriteLine(responseText); // Hooray!
			}
			private static string ReadResponse(HttpWebRequest getRequest)
			{
				using (var responseStream = getRequest.GetResponse().GetResponseStream())
				using (var sr = new StreamReader(responseStream, Encoding.UTF8))
				{
					return sr.ReadToEnd();
				}
			}
			private void FixMisplacedCookie(CookieContainer cookieContainer)
			{
				var misplacedCookie = cookieContainer.GetCookies(new Uri(Url))[0];
				misplacedCookie.Path = "/"; // instead of "/sintegra/servlet/hwsintco"
				//place the cookie in thee right place...
				cookieContainer.SetCookies(
					new Uri("https://www.sefaz.rr.gov.br/"),
					misplacedCookie.ToString());
			}
		}
	}
