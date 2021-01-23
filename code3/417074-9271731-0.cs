    public MembershipStatus AuthenticateLock(string username, string password)
    {
        if(string.IsNullOrEmpty(username))
          return MembershipStatus.InvalidUsername;
        // TODO: Here you must check and clear for non valid characters on mutex name
    	using (var mutex = new Mutex (false, username))
    	{
             // possible lock and wait, more than 16 seconds and the user can go...
    	     mutex.WaitOne (TimeSpan.FromSeconds(16), false);
    	  
             // here I call your function anyway ! and what ever done...
             //  at least I get a result
             return Authenticate(username, password)
    	}
    }
