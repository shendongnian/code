	public class MailTemplate
	{
	    string _mailBody = "";
	    string _subject = "";
	    string _mailFrom = "";
        
        public string MailBody
	    {
	        get { return _mailBody; }
	        set { _mailBody = value ; }
	    }
	
	    public string Subject
	    {
	        get { return _subject; }
	        set { _subject = value; }
	    }
	
	    public string MailFrom
	    {
	        get { return _mailFrom; }
	        set { _mailFrom = value; }
	    }
	}
