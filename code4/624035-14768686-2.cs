    var dt = (DataTable)ViewState["CurrentData"];
    if (dt != null)
    {
         var firstname = (row.FindControl("labelFirstName") as Label).Text; //my guess that you are binding DataRows to labels in grid view? if not this has to be changed
         var lastname = (row.FindControl("labelLastName") as Label).Text; //same as above
         
         var row = dt.AsEnumerable().FirstOrDefault(x => x.Field<string>("First Name") == firstname && x.Field<string>("Last Name") == lastname);
    
         dt.Rows.Remove(row);     
    
         GridView1.DataSource = dt;
         GridView1.DataBind();
    
         GridView2.DataSource = dt;
         GridView2.DataBind();
    
         ViewState["CurrentData"] = dt;
    }
