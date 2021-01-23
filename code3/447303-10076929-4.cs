    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var updateCtrl = e.Row.FindControl("btnUpdate") as Button;
        if (updateCtrl != null)
        {
            var inputCtrl = e.Row.FindControl("txtEnteredDate") as TextBox;
            if (inputCtrl != null)
            {
                inputCtrl.Attributes["onchange"] = string.Format("return validateInput(this.value, '{0}', '{1}');", DataBinder.Eval("DateToCompare"), updateCtrl.ClientID); 
            }
        }
    }    
