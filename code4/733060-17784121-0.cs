    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
          string e_num = Request.QueryString["enum"];
          Label headline_lbl = new Label();
          headline_lbl.Text = db.return_event_name(e_num);
          headline_lbl.CssClass = "head_line";
          head_line_ph.Controls.Add(headline_lbl);
          SqlDataSource2.SelectParameters["num"].DefaultValue = e_num;
          GridView1.DataSourceID = "SqlDataSource2";
          GridView1.DataBind();
            List<string[]> ids_list = db.return_ids_for_event(Convert.ToInt32(e_num));
            foreach (string[] s in ids_list)
            {
                DropDownList1.Items.Add(new ListItem(s[0], s[1]));
            }
        }
    }
