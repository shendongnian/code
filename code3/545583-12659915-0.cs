    public class PidRewriteModule : System.Web.IHttpModule
	{
		public void Dispose()
		{
		}
		public void Init(System.Web.HttpApplication context)
		{
			context.BeginRequest += new EventHandler(context_BeginRequest);
		}
		void context_BeginRequest(object sender, EventArgs e)
		{
			HttpApplication app = sender as HttpApplication;
			if (app != null)
			{
				Match mPidCheck = new Regex(@"^/(?<pid>[0-9]+)/?$").Match(app.Context.Request.Url.AbsolutePath);
				if (mPidCheck.Success)
				{
					app.Context.RewritePath("~/default.aspx", String.Empty, String.Concat("pid=", mPidCheck.Groups["pid"].Value));
				}
			}
			else
				return;
		}
	}
