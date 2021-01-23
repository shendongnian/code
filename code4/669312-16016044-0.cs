    protected void Page_Load(object sender, EventArgs e)
    {
        bool? addBPOP = ViewState["AddBPOP"] as bool?;
        if (addBPOP.HasValue && addBPOP.Value)
        {
            AddBPOP();
        }
    }
    protected void BtnFind_Click(object sender, EventArgs e)
    {
        AddBPOP();
        ViewState["AddBPOP"] = true;
    }
    protected void AddBPOP()
    {
        Usr_BPOP BPOP = (Usr_BPOP)Page.LoadControl("~/Usr_BPOP.ascx");
        BPOP.ID = "BPOPID";
        BPOP.Date = txtDate.Text.Trim();
        BPOP.DocNo = txtDocNo.Text.Trim();
        BPOP.Code = txtCode.Text.Trim();
        BPOP.Name = txtName.Text.Trim();
        BPOP.Partcode = txtPartNo.Text.Trim();
        if (chkReprint.Checked)
        {
            BPOP.BtnReprintVisible = true;
            BPOP.BtnSaveVisible = false;
        }
        divControls.Controls.Clear();
        PlaceHolder1.Controls.Add(BPOP);
    }
