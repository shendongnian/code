     DropDownList ddlSalary = (DropDownList)this.FindControl(MyControls.CountryDDL);
            if (ddlSalary != null)
            {
            ddlSalary.DataSource = MyMethods.LoadCountries();
            ddlSalary.DataValueField = "Value";
            ddlSalary.DataTextField = "Text";
            ddlSalary.DataBind();
            ddlSalary.DataBound += ddlSalary_DataBound;
            }
      protected void ddlSalary_DataBound(object sender, EventArgs e)
      {
          ListItem MovingItem =  ddlSalary.Items.FindByValue("yourvalue");
          ddlSalary.Items.Remove(MovingItem);
          ddlSalary.Items.Insert(0, MovingItem);
      }
   
    
