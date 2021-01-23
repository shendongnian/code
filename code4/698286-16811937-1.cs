    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    ListItemCollection items = new ListItemCollection();
                    items.Add(new ListItem("PNT", "PNT"));
                    items.Add(new ListItem("PNC", "PNC"));
    
                    ddlTypePN.DataSource = items;
                    ddlFctPN.DataBind();
                    ddlTypePN.DataBind(); // The ddl that populate my 2nd ddl
    
                    ddlTypePN.Items.Insert(0, new ListItem("Sélectionnez...", "null"));
                }
            }
    
            protected void ddlTypePN_SelectedIndexChanged(object sender, EventArgs e)
            {
                string type = ddlTypePN.SelectedValue.ToString().Trim();
    
                // if PNT
                if (type.ToUpper().Trim().Equals("PNT"))
                {
                    ddlFctPN.Enabled = true;
                    populateDdl();
    
                }
                else if (type.ToUpper().Trim().Equals("PNC"))
                {
                    ddlFctPN.Enabled = true;
                    populateDdl();
                }        
            }
    
            protected void ddlTypePN_DataBound(object sender, EventArgs e)
            {
    
            }
    
            protected void ddlFctPN_DataBound(object sender, EventArgs e)
            {
    
            }
    
            void populateDdl()
            {
    
                ddlFctPN.Items.Clear();
                lblErr.Visible = false;
    
                try
                {
                    ListItemCollection items = new ListItemCollection();
                    items.Add(new ListItem("One", "1"));
                    items.Add(new ListItem("Two", "2"));
                    items.Add(new ListItem("Three", "3"));
    
                    ddlFctPN.DataSource = items;
                    ddlFctPN.DataBind();
                }
                catch (Exception ex)
                {
                    lblErr.Text = ex.Message;
                    lblErr.Visible = true;
                }
    
    
                ddlFctPN.Items.Insert(0, new ListItem("Sélectionnez...", "null"));
    
            }
    
        }
