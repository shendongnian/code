protected void Page_Load(object sender, EventArgs e)
    {
        btnRefineSearch.Click += new EventHandler(this.btnRefineSearch_Click);
        List<string> LstYears = new List<string>();
        LstYears.Add("one");
        LstYears.Add("two");
        LstYears.Add("three");
        LstYears.Add("four");
        if (!IsPostBack)
        {
            if (LstYears != null)
            {
                for (int i = 0; i < LstYears.Count; i++)
                {
                    cblYearLst.Items.Add(new ListItem(LstYears[i], LstYears[i]));
                }
            }
        }
    }
    private void btnRefineSearch_Click(object sender, EventArgs args)
    {
        Response.Write(cblYearLst.SelectedValue);
    }  
