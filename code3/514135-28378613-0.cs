        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("~/Uploads" + FileUpload1.FileName));
            Label1.Text = "Saved Successfully";
        }
        else 
        {
            Label1.Text = "File Not found";
        }
    }
