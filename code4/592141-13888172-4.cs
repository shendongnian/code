	public bool ExcludeUsers(string[] OmittedUsers)
	{
              string userName = "John";
              bool ConditionMet = true;
            
                  foreach (string userToOmmit in OmittedUsers)
                  {
                      ConditionMet =  string.Compare(userName, userToOmmit) == 0;
 
                    	      if (ConditionMet)
                              return false;
                  }
       	return ConditionMet;
	}
