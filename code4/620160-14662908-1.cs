    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            ViewState["Messages"] = 0;
    }
    public void Send(object sender, EventArgs e)
    {
        error.InnerHtml = string.Empty;
        string message = txtMessage.Text;
        if (message.Length < 20)
        {
            error.InnerHtml = "The message should be at least 20 characters long";
            return;
        }
        int messageNumber = (int)ViewState["Messages"];
        if (messageNumber < 3)
        {
            lbMessages.Items.Add(message);
            ViewState["Messages"] = ++messageNumber;
            if (messageNumber.Equals(3))
                timer.Enabled = true;
        }
    }
    protected void Tick(object sender, EventArgs e)
    {
        ViewState["Messages"] = 0;
        timer.Enabled = false;
    }
