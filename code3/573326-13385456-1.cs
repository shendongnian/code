        protected void btnParent1Upload_Click(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(this).RegisterPostBackControl(this.btnParent1Upload);
            FileUpload FileUpload1 = file_ImageParent1;
            string virtualFolder = "~/UpImages/";
            string physicalFolder = Server.MapPath(virtualFolder);
            FileUpload1.SaveAs(physicalFolder + FileUpload1.FileName);
            lbl_ResultParent1.Text = "Your file " + FileUpload1.FileName + " has been uploaded.";
            Parent1Pic.Visible = true;
            Parent1Pic.ImageUrl = virtualFolder + FileUpload1.FileName;
            byte[] imageBytes = PopulateImageBytes(physicalFolder + FileUpload1.FileName);
            ParentsInfo.Parent1Pic = imageBytes;
            imageBytes = null;
            FileUpload1 = null;
        }
        private static byte[] PopulateImageBytes(string p)
        {
            byte[] imageBytes = File.ReadAllBytes(p);
            return imageBytes;
        }
