    public class ReporterNewsletterMixer
    {
        public Reporter Reporter { get; set; }
        public Newsletter Newsletter { get; set; }
    
        public string Name
        {
            get
            {
                if(Reporter == null)
                    return Newsletter.Name;
                return Reporter.Name;
            }
        }
        //same for status
    
        public ReporterNewsletterMixer(Reporter reporter) { Reporter = reporter; }
        public ReporterNewsletterMixer(Newsletter news) { Newsletter = news; }
    }
