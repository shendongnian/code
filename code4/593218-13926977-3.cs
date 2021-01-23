    public class CommenterBadgeJob : BadgeJob
    {
        public Badge commenter_badge {get;set;}
        public CommenterBadgeJob() : base() 
        {
            //Lookup badge
            string badge_job_name = this.GetType().Name;
            commenter_badge  = db.Badges.Where(n=>n.BadgeJob == badge_job_name).Single();
        }
    
        protected override void AwardBadges()
        {
            //select all users who have more than x comments 
            //and dont have the commenter badge
            //add badges
        }
    
        //run every 10 minutes
        protected override TimeSpan Interval
        {
            get { return new TimeSpan(0,10,0); }
        }
    }
