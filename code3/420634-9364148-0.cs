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
