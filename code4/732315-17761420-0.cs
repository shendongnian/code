    protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      try
      {
      int nmbr = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
      TextBox name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("names");
      TextBox dept = (TextBox)GridView1.Rows[e.RowIndex].FindControl("depts");
      TextBox quantity = (TextBox)GridView1.Rows[e.RowIndex].FindControl("quantitys");
      //do check that any of your controls here is not null
      if(name!=null && dept!=null && quantity !=null)
      {
          con.Open();
          SqlCommand cmds=new SqlCommand("update erbp set name ='" + name.Text + "',dept ='"+ 
              dept.Text+"',quantity='" + quantity.Text + "' where inmbr=" + nmbr , con);
          cmds.ExecuteNonQuery();
          con.Close();
          GridView1.EditIndex = -1;
          BindEmployeeDetails();
      }
      }
      catch(Exception ex)       
      {
          //do exception handling here. 
      }
    }
