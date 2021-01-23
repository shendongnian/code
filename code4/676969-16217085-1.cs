    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='Pointer';this.style.backgroundColor='Yellow'");
           e.Row.RowIndex.ToString())); 
    
            string id = DataBinder.Eval(e.Row.DataItem, "ProductionOrderId").ToString();
            
            // store the id at the client side
            e.Row.Attributes.Add("id", id);
        }
    }
