    public static class MyUserClassExtensions
    {
        public static List<object> GetSampleData(this IMyUserControlMark myUserControl)
        {
            if (HttpContext.Current.Session["MyObject"] == null)
            {
                return Enumerable.Empty<object>().ToList();
            }
            return HttpContext.Current.Session["MyObject"] as List<object>;
        }
        public static void SetSampleData(this IMyUserControlMark myUserControl, List<object> myObject)
        {
            HttpContext.Current.Session["MyObject"] = myObject;
        }
    }
