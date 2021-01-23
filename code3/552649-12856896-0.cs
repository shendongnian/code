    System.Drawing.Image.GetThumbnailImageAbort myCallBack = 
                           new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            Bitmap myBitmap;
           try
            {
                myBitmap = new Bitmap(Server.MapPath(sSavePath + sFilename));
    
                // If jpg file is a jpeg, create a thumbnail filename that is unique.
                file_append = 0;
                string sThumbFile = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName)
                                                         + sThumbExtension + ".jpg";
                while (System.IO.File.Exists(Server.MapPath(sSavePath + sThumbFile)))
                {
                    file_append++;
                    sThumbFile = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + 
                                   file_append.ToString() + sThumbExtension + ".jpg";
                }
    
                // Save thumbnail and output it onto the webpage
                System.Drawing.Image myThumbnail
                        = myBitmap.GetThumbnailImage(intThumbWidth, 
                                                     intThumbHeight, myCallBack, IntPtr.Zero);
                myThumbnail.Save (Server.MapPath(sSavePath + sThumbFile));
                imgPicture.ImageUrl = sSavePath + sThumbFile;
    
                // Displaying success information
                lblOutput.Text = "File uploaded successfully!";
    
                // Destroy objects
                myThumbnail.Dispose();
                myBitmap.Dispose();
            }
            catch (ArgumentException errArgument)
            {
                // The file wasn't a valid jpg file
                lblOutput.Text = "The file wasn't a valid jpg file.";
                System.IO.File.Delete(Server.MapPath(sSavePath + sFilename));
            }
