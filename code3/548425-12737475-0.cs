    public void Page_Load(object sender, EventArgs e)
    {
        this.btnSubmit.Attributes.Add("onclick", "javascript: return confirm('Are you sure?');");
    }
    public void btnSubmit_Click(object sender, EventArgs e)
    {
        //Run code. User already confirmed to get here.
    }
