    protected void lnkDownload_Click(object sender, EventArgs e)
    {
      try
      {
        if(gvrow.RowIndex < 0)   //return if user hasn't selected any row
            return;
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        int field = Convert.ToInt32(gvDetails.DataKeys[gvrow.RowIndex].Value .ToString ());
        SqlDataReader dr = MclsAssignment.getDownload(field);
        if (dr.Read())
        {
          Response.AddHeader("Content-Disposition", "attachment;filename=\"" + dr["mfile_name"] + "\"");
          Response.BinaryWrite((byte[])dr["file_data"]);
          Response.End();
         }
      }
      catch (Exception)
      {       
         throw;
       }
    }
