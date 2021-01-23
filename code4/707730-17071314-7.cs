    using (SvnClient client = new SvnClient())
    {
        // Clear a previous authentication
    	client.Authentication.Clear(); 
    	client.Authentication.DefaultCredentials = new System.Net.NetworkCredential("user", "password");
    }
