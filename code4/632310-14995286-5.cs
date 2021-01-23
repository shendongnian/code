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
     int EmpId = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value);
     if (Session["reptable"] != null)
        {
            DataTable dt1 = new DataTable();
            dt1.Clear();
            dt1 = Session["reptable"] as DataTable;
            for (int i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                DataRow dr;
                if (dt1.Rows[i][0].ToString() == EmpID)
                {
                    dr = dt1.Rows[i];
                    dt1.Rows[i].Delete();
                    //dt1.Rows.Remove(dr);
                }
            }
            Session.Remove("reptable");
            Session["reptable"] = dt1;
        }
        GridData();
     }
     } 
