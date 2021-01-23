        //class variable 'id'
        string id;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    id="";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='Pointer';this.style.backgroundColor='Yellow'");
           e.Row.RowIndex.ToString())); 
            //assign value to id
            id = DataBinder.Eval(e.Row.DataItem, "ProductionOrderId").ToString();
            //no need to return id, you can read it later from the variable 'id'
    
        }
    }
