    memClient.GetUserByUserIdCompleted += (obj, e) => 
    {
    	if (e.Result == null)
    		return;
    	
        lstBxMessages.Items.Add(mes.MessageDate);
    	lstBxMessages.Items.Add(e.Result.UserName);
    }
    memClient.GetUserByUserIdAsync(mes.SenderUserID);
