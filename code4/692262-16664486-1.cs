    protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    if (ViewState["myData"] == null)
                    {
                        // initialize datatable
                        dt = new DataTable();
                        dt.Columns.Add(new DataColumn("Id", typeof(int)));
                        dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
                        dt.Columns.Add(new DataColumn("LastName", typeof(string)));
                        dt.Columns.Add(new DataColumn("FruitID", typeof(int)));
                        dt.Columns[0].AutoIncrement = true;
                        dt.Columns[0].AutoIncrementSeed = 1;
                        // Add sample data
                        for (int i = 0; i <= 5; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["FirstName"] = "Scott";
                            dr["LastName"] = "Tiger";
                            dr["FruitID"] = "2";
                            dt.Rows.Add(dr);
                        }
                        ViewState["myData"] = dt;
                    }
                    else
                    {
                        dt = ViewState["myData"] as DataTable;
                    }
    
                    gvCustomer.DataSource = dt;
                    gvCustomer.DataBind();
                }
    
            }
    protected void btnSave_Click(object sender, EventArgs e)
        {
            // fetch controls from footer
            GridViewRow footerRow = ((Button)sender).NamingContainer as GridViewRow;
            if (footerRow != null)
            {
                // Fetch footer controls
                TextBox txtFirstName = footerRow.FindControl("txtFirstName") as TextBox;
                TextBox txtLastName = footerRow.FindControl("txtLastName") as TextBox;
                DropDownList ddlFruits = footerRow.FindControl("ddlFavFruit") as DropDownList;
                // Save to datatable
                dt = ViewState["myData"] as DataTable;
                DataRow dr = dt.NewRow();
                dr["FirstName"] = txtFirstName.Text.ToString();
                dr["LastName"] = txtLastName.Text.ToString();
                dr["FruitID"] = ddlFruits.SelectedValue;
                dt.Rows.Add(dr);
                gvCustomer.DataSource = dt;
                gvCustomer.DataBind();
                ViewState["myData"] = dt;
            }
        }
