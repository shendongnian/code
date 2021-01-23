    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, myDomainTextBox.Text))
    {
        // validate the credentials
        bool cIsValid = pc.ValidateCredentials(myUserNameTextBox.Text, myPasswordBox.Password);
    
        if (cIsValid)
        {
    		// Do some stuff
    	}
    }
