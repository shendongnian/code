          protected void Button1_Click(object sender, EventArgs e)
             {
                 if (this.FileUpload1.HasFile)
                 {
            if (FileUpload1.PostedFile.ContentType == "image/jpeg")
            {
                if (FileUpload1.PostedFile.ContentLength < 512000)
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~") + "\\" + filename);
                    Watermark w = new Watermark();
                    Byte[] b = w.WatermarkImage(GetBytesFromFile(Server.MapPath("~") + "\\" + filename));
                    MemoryStream ms = new MemoryStream(b);
                    System.Drawing.Image image2 = System.Drawing.Image.FromStream(ms);
                    image2.Save(Server.MapPath("~") + "\\imageTest_op.jpg");
                    Image1.ImageUrl = "imageTest_op.jpg";
                }
                     }
                 }
             }
