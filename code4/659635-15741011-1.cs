    protected int NumberOfControls
    {
        get { return Convert.ToInt32(Session["noCon"]); }
        set { Session["noCon"] = value.ToString(); }
    }
    private void Page_Init(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
            //Initiate the counter of dynamically added controls
            this.NumberOfControls = 0;
        else
            //Controls must be repeatedly be created on postback
            this.createControls();
    }
    private void Page_Load(object sender, System.EventArgs e)
    {
        
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        TextBox tbx = new TextBox();
        tbx.ID = "txtData"+NumberOfControls;
        NumberOfControls++;
        PlaceHolder1.Controls.Add(tbx);
    }
    protected void btnRead_Click(object sender, EventArgs e)
    {
        int count = this.NumberOfControls;
        for (int i = 0; i < count; i++)
        {
            TextBox tx = (TextBox)PlaceHolder1.FindControl("txtData" + i.ToString());
            //Add the Controls to the container of your choice
            Label1.Text += tx.Text + ",";
        }
    }
    
    private void createControls()
    {
        int count = this.NumberOfControls;
        for (int i = 0; i < count; i++)
        {
            TextBox tx = new TextBox();
            tx.ID = "txtData" + i.ToString();
            //Add the Controls to the container of your choice
            PlaceHolder1.Controls.Add(tx);
        }
    }
