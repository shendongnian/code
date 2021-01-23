    protected void Button2_Click(object sender, EventArgs e)
     {
       if (FileUpload1.HasFile)
        {
          .....
          ViewState["file1"]=Server.MapPath("~/upload/" + FileUpload1.FileName);
          ....
        }
     }
    
     protected void Button3_Click(object sender, EventArgs e)
     {
       if (FileUpload2.HasFile)
        {
          .....
          ViewState["file2"]=Server.MapPath("~/upload/" + FileUpload2.FileName);
          ....
        }
     }
