    static void Call2()
    {
    	WebHandler web = new WebHandler();
    	List<Task> tasks = new List<Task>();
    
    	foreach (var ip in IPs)
    	{
    		var ipCopy = ip;
    		tasks.Add(Task<bool>.Factory.StartNew(() => web.MakeWebRequest(String.Format(Url, ipCopy), ipCopy)));
    	}
    
    	Task.WaitAll(tasks.ToArray());
    }
