    public partial class TwitterStatus
    {
            public string MinAgo 
            {
                get 
                {
                    TimeSpan diff = DateTime.Now.Subtract(this.CreatedDate);
                    return diff.Minutes.ToString() + "m";
                }
            }
    }
    //Use
    {
        IEnumerable<TwitterStatus> mentions = service.ListTweetsOnHomeTimeline();
        foreach(var mention in mentions)
        {
            var minAgo = mention.MinAgo;
            //Do somthing with minAgo
        }
    }
