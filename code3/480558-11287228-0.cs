    public void EditTable()
    {
        ICollection trends = CreateDataSource();
        for (int x = 1; x <= 27; x++)
        {
            DropDownList ddl = new DropDownList();
            string index = x.ToString();
            ddl.ID = "TrendList" + index;
            ddl.AutoPostBack = true;
            ddl.SelectedIndexChanged += new EventHandler(this.Selection_Change);
            ddl.DataSource = trends;
            ddl.DataTextField = "TrendTextField";
            ddl.DataValueField = "TrendValueField";
            ddl.DataBind();
            if (!IsPostBack)
            {
                ddl.SelectedIndex = 0;
            }
            HtmlGenericControl span = (HtmlGenericControl)form1.FindControl("s" + index);
            PlaceHolder placeHolder = (PlaceHolder)span.FindControl("p" + index);
            if (placeHolder != null)
            {
                placeHolder.Controls.Add(ddl);
            }
        }
    }
