    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string myMessage = "";
            // Code: string myMessage = Get Message from Database to write to div
            MyTestDiv.InnerText = myMessage;
        }
    }
