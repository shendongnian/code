     protected void Pager_PreRender(object sender, EventArgs e)
            {
                if (IsPostBack)
                {
                       string keyword = txtSearch.Text.Trim();
    
    
                        List<dynamic> Cresults = AdminSearchAll(keyword);
                    
    
                        if (Cresults.Count != 0)
                        {
    
                            LVCAdmin.DataSource = Cresults;
                            LVCAdmin.DataBind();
    
                            NoResults.Visible = false;
                            LVCAdmin.Visible = true;
                        }
                        else
                        {
    
                            NoResults.Visible = true;
    
                            LVCAdmin.Visible = false;
    
    
                        }
    
                    }
              
            }
