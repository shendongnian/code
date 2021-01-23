        private string doUpload()
        {
            // Initialize variables
            string sSavePath;
            sSavePath = "images/";
            // Check file size (mustn’t be 0)
            HttpPostedFile myFile = FileUpload1.PostedFile;
            int nFileLen = myFile.ContentLength;
            if (nFileLen == 0)
            {
                //**************
                //lblOutput.Text = "No file was uploaded.";
                return null;
            }
            // Check file extension (must be JPG)
            if (System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".jpg")
            {
                //**************
                //lblOutput.Text = "The file must have an extension of JPG";
                return null;
            }
            // Read file into a data stream
            byte[] myData = new Byte[nFileLen];
            myFile.InputStream.Read(myData, 0, nFileLen);
            // Make sure a duplicate file doesn’t exist.  If it does, keep on appending an 
            // incremental numeric until it is unique
            string sFilename = System.IO.Path.GetFileName(myFile.FileName);
            int file_append = 0;
            while (System.IO.File.Exists(Server.MapPath(sSavePath + sFilename)))
            {
                file_append++;
                sFilename = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName)
                                 + file_append.ToString() + ".jpg";
            }
            // Save the stream to disk
            System.IO.FileStream newFile
                    = new System.IO.FileStream(Server.MapPath(sSavePath + sFilename),
                                               System.IO.FileMode.Create);
            newFile.Write(myData, 0, myData.Length);
            newFile.Close();
            return sFilename;
        }
