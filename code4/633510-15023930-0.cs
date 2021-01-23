    void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if(e.Row.RowType == DataControlRowType.DataRow)
      {
         HtmlGenericControl div = (HtmlGenericControl)e.FindControl("cst_checkbox_container1");
         div.Attributes["class"] = "some_class";
      }
    }
