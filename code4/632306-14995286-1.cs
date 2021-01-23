       protected void btnDelete_Click(object sender, EventArgs e)
          {
      //Loop through all the rows in gridview
      foreach(GridViewRow gvrow in gvUserDetails.Rows)
     {
     //Finiding checkbox control in gridview for particular row
     CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkdelete");
    //Condition to check checkbox selected or not
    if(chkdelete.Checked)
     {
     //Getting UserId of particular row using datakey value
     int usrid = Convert.ToInt32(gvUserDetails.DataKeys[gvrow.RowIndex].Value);
      objUsers.DeleteParameters["UserId"].DefaultValue = usrid.ToString();
      objUsers.Delete();
     }
     } 
