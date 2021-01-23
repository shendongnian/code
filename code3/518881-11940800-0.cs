    protected void Button1_Click(object sender, EventArgs e)
       {
           // Get User ID from DAL
           int chk = 0;
           string emailID = ""; 
           if (Session["EmailID"] != null)
           {
               emailID = Session["EmailID"].ToString();
           }           ProfileMasterBLL prfbll = new ProfileMasterBLL();
           string userid = ProfileMasterDAL.GetUserIdByEmailID(emailID);   
