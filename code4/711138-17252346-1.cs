    string dn = "/O=CHEESE/OU=FIRST ADMINISTRATIVE GROUP/" +
    		"CN=RECIPIENTS/CN=LHALA1";
    string MailAddress=string.Empty;
    string user = string.Empty;
    
    using (DirectorySearcher ds = new DirectorySearcher())
    {
    	ds.Filter = string.Format("(&(ObjectClass=User)(legacyExchangeDN={0}))", 
    			dn);
    	SearchResultCollection src = ds.FindAll();
    	if (src.Count > 1)
    	{
    		//Oops too many!
    	}
    	else
    	{
    		user = src[0].Properties["samAccountName"][0].ToString();
    		MailAddress = src[0].Properties["Mail"][0].ToString();
    	}
    }
