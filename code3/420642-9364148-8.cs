    public static class ExtensionClasses
    {
        public static string MinAgo(this TwitterStatus status)
        {
            TimeSpan diff = DateTime.Now.Subtract(status.CreatedDate);
            return diff.Minutes.ToString() + "m";
        }
    }
    //Use
    {
        IEnumerable<TwitterStatus> mentions = service.ListTweetsOnHomeTimeline();
        foreach(var mention in mentions)
        {
            var minAgo = mention.MinAgo();
            //Do somthing with minAgo
        }
    }
