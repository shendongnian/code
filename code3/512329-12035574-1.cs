    public static class PagerOptionsBuilderExtensions
    {
        public static PagerOptionsBuilder AddFromQueryString(
            this PagerOptionsBuilder builder, 
            HttpRequestBase request
        )
        {
            foreach (string item in request.QueryString)
            {
                builder.AddRouteValue(item, request.QueryString[item]);
            }
            return builder;
        }
    }
