	public class Error404Resolver : Sitecore.Pipelines.HttpRequest.HttpRequestProcessor
	{
		public override void Process(Sitecore.Pipelines.HttpRequest.HttpRequestArgs args)
		{
			if(Sitecore.Context.Item == null && !args.Context.Request.Url.AbsolutePath.StartsWith("/sitecore")
			{
				args.Context.Response.Clear();
				SiteContext site = Sitecore.Context.Site;
				if(site != null)
				{
					Item item404Page = Sitecore.Context.Database.GetItem(site.RootPath + "website/error/404");
					if(item404Page != null)
					{
						Sitecore.Context.Item = item404Page;
						args.Context.Response.StatusCode = (int) System.Net.HttpStatusCode.NotFound;
					}
				}
			}
		}
	}
