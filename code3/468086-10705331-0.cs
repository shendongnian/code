    protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (file.HasFile)
            {
                try
                {
                    if (file.PostedFile.ContentType == "application/octet-stream")
                    {
                        string filename = Path.GetFileName(file.FileName);
                        file.SaveAs(Server.MapPath("~/datafiles/") + filename);
                        lblStatus.ForeColor = Color.Green;
                        lblStatus.Text = "Upload status: File uploaded!";
                    }
                    else
                    {
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.Text = "Upload status: Only .CSV files are accepted! This is a " + file.PostedFile.ContentType + " file";
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
