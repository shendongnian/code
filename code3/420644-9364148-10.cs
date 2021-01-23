    //This code is untested and not gaunteed to work,
    public class NewTwitterStatus
    {
        private NewTwitterStatus(TwitterStatus twitterStatus)
        {
            this.twitterStatus = twitterStatus;
        }
        private TwitterStatus twitterStatus
        public string MinAgo 
        {
            get 
            {
                TimeSpan diff = DateTime.Now.Subtract(base.CreatedDate);
                return diff.Minutes.ToString() + "m";
            }
        }
        public static implicit operator NewTwitterStatus(TwitterStatus status)
        {
            return new NewTwitterStatus(status);
        }
        public static implicit operator TwitterStatus(NewTwitterStatus status)
        {
            return status.twitterStatus;
        }
        //You will need to do this for ever function/Member in TwitterStatus
        public bool SomeFuncFromTwitterStatus()
        {
            return this.twitterStatus.SomeFuncFromTwitterStatus();
        }
    }
    //Use
    {
        IEnumerable<NewTwitterStatus> mentions = service.ListTweetsOnHomeTimeline();
        foreach(var mention in mentions)
        {
            var minAgo = mention.MinAgo();
            //Do somthing with minAgo
        }
    }
