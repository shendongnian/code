    public Dictionary<Guid, string> UcList
    {
        get { return ViewState["MyUcIds"] != null ? (Dictionary<Guid, string>)ViewState["MyUcIds"] : new Dictionary<Guid, string>(); }
        set { ViewState["MyUcIds"] = value; }
    }
    public void InitializeUC()
    {
        int index = 1;
        foreach (var item in UcList)
        {
            var myUc = (UserControls_uc_MyUserControl)LoadControl("~/UserControls/uc_MyUserControl.ascx");
            myUc.ID = item.Value;
            pnlMyUC.Controls.AddAt(index, myUc);
            index++;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadControl();
        else
            InitializeUC();
    }
