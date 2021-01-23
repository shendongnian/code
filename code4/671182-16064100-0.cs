    string name = "SampleServiceIdentity";
    string password = "SampleServiceIdentityPassword";
    ServiceIdentity sid = new ServiceIdentity()
    {
    	Name = name
    };
    
    DateTime startDate, endDate;
    startDate = DateTime.UtcNow;
    endDate = DateTime.MaxValue;
    
    ServiceIdentityKey key = new ServiceIdentityKey()
    {
    	EndDate = endDate.ToUniversalTime(),
    	StartDate = startDate.ToUniversalTime(),
    	Type = "Password",
    	Usage = "Password",
    	Value = Encoding.UTF8.GetBytes(password),
    	DisplayName = String.Format(CultureInfo.InvariantCulture, "{0} key for {1}", "Password", name)
    };
    
    svc.AddToServiceIdentities(sid);
    svc.AddRelatedObject(
    	sid,
    	"ServiceIdentityKeys",
    	key);
    
    
    svc.SaveChanges(SaveChangesOptions.Batch);
    
