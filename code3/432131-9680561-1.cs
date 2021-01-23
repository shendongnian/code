    public class JobApplicantSession
    {
        public JobApplication Application 
        {
            get
            {
                return (JobApplication)HttpContext.Current.Session["Application"];
            }
            set
            {
                HttpContext.Current.Session["Application"] = value;
            }
        }
    }
