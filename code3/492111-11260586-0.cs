    public static class RequestExtensions
    {
        public static string QueryStringValue(this HttpRequest request, string parameter)
        {
            return !string.IsNullOrEmpty(request.QueryString[parameter]) ? request.QueryString[parameter] : string.Empty;
        }
        public static bool QueryStringValueMatchesExpected(this HttpRequest request, string parameter, string expected)
        {
            return !string.IsNullOrEmpty(request.QueryString[parameter]) && request.QueryString[parameter].Equals(expected, StringComparison.OrdinalIgnoreCase);
        }
    }
