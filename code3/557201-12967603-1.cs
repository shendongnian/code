    public bool CheckUserExistAndReporter(string user)
    {
        bool isValidUser = false;
    
        SMSFunctionController mysms = new SMSFunctionController();
        DataSet uds = mysms.GetUsersUnitByUserName(user);
    
        if (uds != null && uds.Tables.Count > 0 && uds.Tables[0].Rows.Count>0)
        { 
            // do further validation
            var reporterDnnId = Convert.ToInt32(uds.Tables[0].Rows[0]["DnnUserID"]);
            if (reporterDnnId > 0)
            {
               isValidUser = true;         
            }
        }
        return isValidUser;  
    }   
 
    
   
