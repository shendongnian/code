    void Main()
    {
    	var hugeListOfEmails = GetHugeListOfEmails();
    	var allBouncedEmails = GetAllBouncedEmails();
    	IDictionary<string, EmailInfo> CreateLookupOfBouncedEmails = CreateLookupOfBouncedEmails(allBouncedEmails);
    	
    	foreach(var info in hugeListOfEmails)
    	{
    		if(CreateLookupOfBouncedEmails.ContainsKey(info.emailAddress))
    		{
    			// Email is bounced;
    		}
    		else
    		{
    			// Email is not bounced
    		}
    	}
    	
    }
    
    public IEnumerable<EmailInfo> GetHugeListOfEmails()
    {
    	yield break;
    }
    
    public IEnumerable<EmailInfo> GetAllBouncedEmails()
    {
    	yield break;
    }
    
    public IDictionary<string, EmailInfo> CreateLookupOfBouncedEmails(IEnumerable<EmailInfo> emailList)
    {
    	var result = new Dictionary<string, EmailInfo>();
    	foreach(var e in emailList)
    	{
    		if(!result.ContainsKey(e.emailAddress))
    		{
    			if(//satisfies the date conditions)
    			{
    				result.Add(e.emailAddress, e);
    			}
    		}
    	}
    	return result;
    }
    
    public class EmailInfo
    {
    	public string emailAddress { get; set; }
    	public DateTime DateSent { get; set; }
    }
