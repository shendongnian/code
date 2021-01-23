    protected void Page_Init(object sender, EventArgs e)
    {
        BANANA.Web.Controls.BoundDataField field = null;
        BANANA.Web.Controls.TemplateField tField = null;
        tField = new BANANA.Web.Controls.TemplateField();
        tField.ItemTemplate = new GridViewRadioButtonTemplate("APPSTATUS", _strRadioButtonID);
        tField.ID = "APPSTATUS";
        tField.Width = 30;
        tField.HorizontalAlignment = BANANA.Web.Controls.HorizontalAlignment.Center;
        this.FixedGrid1.Columns.Add(tField);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FixedGrid1.DataSource = _dt;
            FixedGrid1.DataBind();
        }
    }
