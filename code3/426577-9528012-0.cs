    var physician = (from userAccounts in myDb.Physicians
                                where userAccounts.Phy_UserName == txtUserName.Text
                                select userAccounts).FirstOrDefault();
    
    if(physician != null)
    {
      setFirstName(physician.Phy_FName);
    }
    else
    {
      //Throw Error or any any other processing as needed.
    }
 
