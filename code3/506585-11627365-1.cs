     protected void ListView2_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
               
                case "Insert":
    string Imagepath = "~/UploadedImages/";
                    FileUpload fu2 = (FileUpload)ListView2.InsertItem.FindControl("PictureIDUploader");
                    if (fu2.HasFile)
                    {
                        string exten = Path.GetExtension(Server.MapPath(fu2.FileName));
                        string Filename2 = DateTime.Now.ToOADate().ToString() + exten;
                        Session["TheImage"] = Filename2;
                        string FileExtension = Path.GetExtension(Filename2).ToString();
                        string filepath = Path.Combine(Server.MapPath(Imagepath)) + Session["TheImage"].ToString();
                        fu2.SaveAs(filepath);
                    }
                    else
                    {
                        Session["TheImage"] = "NoImage.png";
                    }
                    //Hiding the insert template
                    break;
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = ex.Message;
        }
    }
