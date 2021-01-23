    GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) 
    { 
        GridView1.PageIndex = e.NewPageIndex;
    
            if(ViewState["searchTerm"] != null)
            {
                object a = ViewState["searchTerm"];
                string reloadTerm = a.ToString();
    
                setGrid(reloadTerm);
           }
           GridView1.DataBind();
    }
