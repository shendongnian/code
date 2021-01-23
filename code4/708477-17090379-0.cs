    string ProfileID, UserID, redirectUrl;
    try
    {
        ProfileID = Request.QueryString["ProfileID"].ToString();
        string SelectQuery;
        DataSet ds;
        try
        {
            UserID = Session["UserID"].ToString();
            if (ProfileID == UserID)
            {
                redirectUrl = "user/Default.aspx";
            }
            else
            {
               //some code here
            }
        }
        finally
        {
          //some code here
        }
    }
    catch 
    {
        redirectUrl = "DoesNotExists.aspx";
    }
    if(!string.IsNullOrEmpty(redirectUrl))
        Response.Redirect(redirectUrl);
