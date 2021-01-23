    public class JobApplicantSession
    {
        public int Application 
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
