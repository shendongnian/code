                Guid uid1 = Guid.NewGuid();
                string PhotoPath1 = Server.MapPath("~/Employee/EmpPngPhoto/") + lblCode.InnerText;
                string SavePath1 = PhotoPath1 + "\\" + imgName + ".png";
                if (!(Directory.Exists(PhotoPath1)))
                {
                    Directory.CreateDirectory(PhotoPath1);
                }
                System.Drawing.Bitmap bmpImage1 = new System.Drawing.Bitmap(fuPhotoUpload.PostedFile.InputStream);
                System.Drawing.Image objImage1 = ScaleImage(bmpImage1, 160);
                objImage.Save(SavePath1, ImageFormat.Png);
                #endregion
