     foreach (GridViewRow row in ViewData.Rows)
     {
          RadioButton rb = (RadioButton)row.FindControl("RowSelector");
          if (rb.Checked)
          {                                            
             string address = Convert.ToString(ViewData.Rows[row.RowIndex].Cells[column-index].Text);
             Session["addressValue"] = address;                   
             Response.Redirect("AnotherPage.aspx");
         }
     }
