    protected void Page_Init(object sender, EventArgs e)
    {
        BirthDateWebUserControl bc = new BirthDateWebUserControl();
        bc.ID = "bcInPanel";
        PanelForm.Controls.Add(bc);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // init with some date in case not post back
            ((BirthDateWebUserControl)PanelForm.FindControl("bcInPanel")).BirthDate = new DateTime(1950, 4, 12);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var bc = (BirthDateWebUserControl)PanelForm.FindControl("bcInPanel");
        LabelResult.Text = bc.BirthDate.ToString("dd/MM/yy");
    } 
