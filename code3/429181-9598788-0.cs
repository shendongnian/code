     DropDownList ddlSalary = (DropDownList)this.FindControl(MyControls.CountryDDL);
            if (ddlSalary != null)
            {
            ddlSalary.DataSource = MyMethods.LoadCountries();
            ddlSalary.DataValueField = "Value";
            ddlSalary.DataTextField = "Text";
            ddlSalary.DataBind();
            ddlSalary.DataBound = ddlSalary_DataBound;
            }
      protected void ddlSalary_DataBound(object sender, EventArgs e)
      {
         // ...find the item and move it
      }
   
    
