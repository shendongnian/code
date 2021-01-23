    public DataSet CustomGetAllUsers()    {
    	    DataSet ds = new DataSet();
    	    DataTable dt = new DataTable();
    	    dt = ds.Tables.Add("Users");
     
    	    MembershipUserCollection muc;
    	    muc = Membership.GetAllUsers();
    	 
    	    dt.Columns.Add("UserName", Type.GetType("System.String"));
    	    dt.Columns.Add("Email", Type.GetType("System.String"));
    	    dt.Columns.Add("CreationDate", Type.GetType("System.DateTime"));
    	 
    	    /* Here is the list of columns returned of the Membership.GetAllUsers() method
    	     * UserName, Email, PasswordQuestion, Comment, IsApproved
    	     * IsLockedOut, LastLockoutDate, CreationDate, LastLoginDate
    	     * LastActivityDate, LastPasswordChangedDate, IsOnline, ProviderName
    	     */
    	 
    	    foreach(MembershipUser mu in muc) {
    	        DataRow dr;
    	        dr = dt.NewRow();
    	        dr["UserName"] = mu.UserName;
    	        dr["Email"] = mu.Email;
    	        dr["CreationDate"] = mu.CreationDate;
    	        dt.Rows.Add(dr);
    	    }
    	    return ds;
    	}
