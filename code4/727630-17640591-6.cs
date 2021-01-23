    // creates 1 panel on the first load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FormCount = 1;
        }
        CreatePanels();
    }
    // first line is added to grab the all panels in phFormContent before passing to the pdf creation routine
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        panels = phFormContent.Controls.OfType<Panel>().ToList();
        PDFDocument form = CreatePDF(this);
        Response.ContentType = "application/x-msdownload";
        Response.AddHeader("content-disposition", "attachment;filename=form.pdf");
        form.Save(Response.OutputStream);
        Response.Flush();
        Response.End();
    }
    // when adding we just inc the form counter and add a panel
    protected void btnAddForm_Click(object sender, EventArgs e)
    {
        FormCount = FormCount + 1;
        CreatePanel();
    }
    // routine to create the form panels
    protected void CreatePanels()
    {
        for (int i = 0; i < FormCount; i++)
        {
            CreatePanel();
        }
    }
    // this just creates a panel now and appends to placeholder;
    protected void CreatePanel()
    {
        // Create Labels
        Label lblName = new Label();
        lblName.Text = "NAME:";
        Label lblNumber = new Label();
        lblNumber.Text = "NUMBER:";
        Label lblAddress = new Label();
        lblAddress.Text = "ADDRESS:";
        Label lblCompany = new Label();
        lblCompany.Text = "COMPANY:";
        // Create Text Boxes
        TextBox txtName = new TextBox();
        TextBox txtNumber = new TextBox();
        TextBox txtAddress = new TextBox();
        TextBox txtCompany = new TextBox();
        // Create submit button
        Button btnSubmit = new Button();
        btnSubmit.Text = "SUBMIT";
        // Create panel and add controls
        Panel pnlForm = new Panel();
        pnlForm.EnableViewState = true;
        pnlForm.Controls.Add(lblName);
        pnlForm.Controls.Add(txtName);
        pnlForm.Controls.Add(new LiteralControl("<br /><br />"));
        pnlForm.Controls.Add(lblNumber);
        pnlForm.Controls.Add(txtNumber);
        pnlForm.Controls.Add(new LiteralControl("<br /><br />"));
        pnlForm.Controls.Add(lblAddress);
        pnlForm.Controls.Add(txtAddress);
        pnlForm.Controls.Add(new LiteralControl("<br /><br />"));
        pnlForm.Controls.Add(lblCompany);
        pnlForm.Controls.Add(txtCompany);
        pnlForm.Controls.Add(new LiteralControl("<hr />"));
        pnlForm.Controls.Add(new LiteralControl("<br /><br />"));
        phFormContent.Controls.Add(pnlForm);
    }
    // keeps track of how many panels we need to recreate.
    public int FormCount
    {
        get
        {
            if (ViewState["FormCount"] != null)
            {
                return (int)ViewState["FormCount"];
            }
            return 1;
        }
        set
        {
            ViewState["FormCount"] = value;
        }
    }
