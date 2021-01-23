    protected void btnup_Click(object sender, EventArgs e)
            {
                if (ASPxUploadControl1.HasFile)
                {
                    try
                    {
                        string ext = Path.GetExtension(ASPxUploadControl1.FileName);
                        string filename = DateTime.Now.Ticks.ToString()+ext;
                        ASPxUploadControl1.SaveAs(Server.MapPath("upload/") + filename);
                        StatusLabel.Text = "Upload status: File uploaded!";
                    }
                    catch (Exception ex)
                    {
                        StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    }
                }
        }
