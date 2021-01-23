    class FeedResult : ActionResult
    {
        private SyndicationFeedFormatter formattedFeed;
        public FeedResult(SyndicationFeedFormatter formattedFeed)
        {
            this.formattedFeed = formattedFeed;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";
            using (XmlWriter writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                formattedFeed.WriteTo(writer);
            }
        }
    }
