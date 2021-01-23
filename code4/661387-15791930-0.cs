     protected void FormView1_DataBound(object sender, EventArgs e)
        {
            DropDownList ddlType = null;
            if (FormView1.Row != null)
            {
                ddlType = (DropDownList)FormView1.Row.FindControl("ddlType");
            }
         }
