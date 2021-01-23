    GridView.DataSouce = theData;
    GridView.DataBind();
    //index refers to the column number of the template field
    for (int i=0; i<in GridView.Rows.Count; i++)
    {
        Label a = (Label)GridView.Rows[i].Cells[index].FindControl("NoLink");
        LinkButton b = (LinkButton)GridView.Rows[i].Cells[index].FindControl("WithLink");
    
        if (// link exists)
        {
            a.Visible = false;
            b.Visible = true;
        }
    
        else)
        {
            a.Visible = true;
            b.Visible = false;
        }  
    }
