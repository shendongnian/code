    if (!IsPostBack)
    {
       SqlConnection myConnection = new SqlConnection("Server=xyz;Database=db;Uid=db;Pwd=12345");
        try 
        {
           myConnection.Open();         
           SqlDataReader myReaderddl = null;
           SqlCommand myCommandddl = new SqlCommand("SELECT [username], [fullname] FROM [qa_users]", myConnection);
           myReaderddl = myCommandddl.ExecuteReader();
           if (myReaderddl.HasRows())
           {
              ddlrep.DataSource = myReaderddl;                    
              ddlrep.DataValueField = "username";
              ddlrep.DataTextField = "fullname";
              ddlrep.DataBind();
           }
        }
        finally 
        {
           if (myConnection != null)
           {
              myConnection.Close();
           }
        }
    }
