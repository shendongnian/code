    protected void Page_Load(object sender, EventArgs e)
    {
      if (Page.IsPostBack) return;
      LoadCountryList();
    }
    private void LoadCountryList()
    {
      _ctx = new PayLinxDataContext();
      chkCountries.DataSource = _ctx.Countries.OrderBy(c => c.Name);
      chkCountries.DataBind();
      foreach (ListItem item in chkCountries.Items)
      {
        item.Selected = true;
      }
    }
