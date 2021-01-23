    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) FillList();
    
        if (Request.QueryString["id"] != null)
        {
            FillData();
            div_General.Visible = true;
            div_Special.Visible = true;
            hiddenfield1.Value =  dropdownlist1.SelectedValue.text;
        }
    }
