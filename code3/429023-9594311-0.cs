        //in Global.asax.cs
        protected virtual void Application_BeginRequest (Object sender, EventArgs e)
		{
			if(Request.Url.Host=="www.earlz.biz.tm" || Request.Url.Host=="earlz.biz.tm" || Request.Url.Host=="www.lastyearswishes.com"){
				Response.Status = "301 Moved Permanently";
				Response.AddHeader("Location","http://lastyearswishes.com"+Request.Url.PathAndQuery);
				CompleteRequest(); //I believe this is the missing piece in your code.
			}
			
		}
