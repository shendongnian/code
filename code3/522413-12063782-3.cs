	<%@ WebHandler Language="C#" Class="CookieTest" %>
	using System;
	using System.Net;
	using System.Web;
	public class CookieTest : IHttpHandler
	{
		public class WebClientEx : WebClient
		{
			private CookieContainer _cookieContainer = new CookieContainer();
			protected override WebRequest GetWebRequest(Uri address)
			{
				WebRequest request = base.GetWebRequest(address);
				if (request is HttpWebRequest)
				{
					(request as HttpWebRequest).CookieContainer = _cookieContainer;
					(request as HttpWebRequest).AllowAutoRedirect = true;
					(request as HttpWebRequest).Timeout = 10000;
				}
				return request;
			}
		}
		public void ProcessRequest(HttpContext ctxt)
		{
			ctxt.Response.ContentType = "text/plain";
			String cmd = ctxt.Request["cmd"];
			if (cmd == "set")
			{
				ctxt.Response.Cookies.Add(new HttpCookie("test", "test"));
				ctxt.Response.Write("Cookie Set: test = test");
			}
			else if (cmd == "get")
			{
				ctxt.Response.Write("Cookie Value: test = " + ctxt.Request.Cookies["test"].Value);
			}
			else
			{
				// run out tests
				WebClientEx wc = new WebClientEx();
				ctxt.Response.Write("Running tests on .NET version: " + Environment.Version);
				ctxt.Response.Write(Environment.NewLine + Environment.NewLine);
				ctxt.Response.Write("Setting Cookie...");
				ctxt.Response.Write(Environment.NewLine + Environment.NewLine);
				ctxt.Response.Write("Response: " + wc.DownloadString(ctxt.Request.Url.AbsoluteUri + "?cmd=set"));
				ctxt.Response.Write(Environment.NewLine + Environment.NewLine);
				ctxt.Response.Write("Getting Cookie...");
				ctxt.Response.Write(Environment.NewLine + Environment.NewLine);
				ctxt.Response.Write("Response: " + wc.DownloadString(ctxt.Request.Url.AbsoluteUri + "?cmd=get"));
				ctxt.Response.Write(Environment.NewLine + Environment.NewLine);
			}
		}
 
		public bool IsReusable
		{
			get { return true; }
		}
	}
