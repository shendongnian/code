    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (Settings.Default.CDNEnable)
            {
                filters.Add(new Filters.CDNUrlFilter());
            }
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.InitializeSimpleMembershipAttribute());
            filters.Add(new Filters.RequestTimingFilter());
        }
    }
