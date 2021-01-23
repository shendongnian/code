    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var inputCtrl = e.Row.FindControl("txtEnteredDate") as TextBox;
        if (inputCtrl != null)
        {
            var updateButtonCtrl = e.Row.FindControl("btnUpdate") as Button;
            if (updateButtonCtrl != null)
            {
                inputCtrl.Attributes["onchange"] = string.Format("return validateInput(this.value, '{0}', '{1}');", DataBinder.Eval("DateToCompare"), updateButtonCtrl.ClientID);
            }
        }
    }    
