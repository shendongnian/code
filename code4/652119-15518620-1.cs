    protected void ddlist_onSelectIndexChanged(object sender, EventArgs e)
     {
               string selectedBranch=ddlBranch.SelectedItem.Text;
               
               DataSet dsBranchDetails=GetDataForBranch(selectedBranch);
    
                GridView1.DataSource=dsBranchDetails;
                GridView1DataBind();
     }
    
    
    public DataSet GetDataForBranch(string selectedBranch)
    {
     //     your code
    }
