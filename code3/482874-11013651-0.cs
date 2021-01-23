    internal static class RequestContext
    {
        internal static MyDbContext Current
        {
            get
            {
                if (!HttpContext.Current.Items.Contains("myContext"))
                {
                    HttpContext.Current.Items.Add("myContext", new MyDbContext());
                }
                return HttpContext.Current.Items["myContext"] as MyDbContext;
            }
        }
    }
