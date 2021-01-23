    protected void ddlServer_SelectedIndexChanged(object sender, EventArgs e)
     {
    ddlSourceDatabases.Items.Clear();
    lbxSourceTables.Items.Clear();
    if (ddlSourceServers.SelectedIndex != 0)
    {
       try
       {
           ddlSourceDatabases.DataSource = Database.GetDatabases(ddlSourceServers.Text);
           ddlSourceDatabases.DataTextField = "name";
           ddlSourceDatabases.DataValueField = "name";
           ddlSourceDatabases.DataBind();
          
          ddlSourceDatabases.Items.Add("Select Source Database");
        }
        catch (Exception)
        {               
        }
     }
     
    }
