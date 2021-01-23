    void GridView1GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    { 
     if(e.Row.RowType == DataControlRowType.DataRow)
     {
      //find the control
      var label1 = e.Item.FindControl("label1") as Label;
      if (label1 != null)
      {
       if (!string.IsNullOrEmpty(tbInput1.Text) && !string.IsNullOrEmpty(tbInput2.Text))
       {
          // Do the calculation and set the label
          label1.Text = tbInput1.Text + tbInput2.Text;
          // Make the column visible
          GridView1.Columns[0].Visible = true;
       }
      }
     }
    }
