    protected void Page_Load(object sender, EventArgs e)
    {
    string messageIn=string.Empty;
        if (!IsPostBack)
        {
            try
            {
    
                 messageIn = Request.QueryString["msg"];
    
                // some code here
    
    
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
    
    
            string[] msg_arr = messageIn.Split(' '); // error shown here
            int size = msg_arr.Length;
    
            if(!CheckUserExistAndReporter("messageIn"))
            {
               // Response.Redirect("~/test.aspx");
            }
            
