     private void DownloadFile()
        {
    
    
            string getPath = "DOWNLOAD/FileName.zip";
            System.IO.Stream iStream = null;
    
            byte[] buffer = new Byte[1024];
    
            // Length of the file:
            int length;
    
            // Total bytes to read:
            long dataToRead;
    
            // Identify the file to download including its path.
            string filepath = Server.MapPath(getPath);
    
            // Identify the file name.
            string filename = System.IO.Path.GetFileName(filepath);
            try
            {
                // Open the file.
                iStream = new System.IO.FileStream(filepath, System.IO.FileMode.Open,
                            System.IO.FileAccess.Read, System.IO.FileShare.Read);
    
    
                // Total bytes to read:
                dataToRead = iStream.Length;
                // Page.Response.ContentType = "application/vnd.android.package-archive";
                //   Page.Response.ContentType = "application/octet-stream";
                Page.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
    
                // Read the bytes.
                while (dataToRead > 0)
                {
                    // Verify that the client is connected.
                    if (Response.IsClientConnected)
                    {
                        // Read the data in buffer.
                        length = iStream.Read(buffer, 0, 1024);
    
                        // Write the data to the current output stream.
                        Page.Response.OutputStream.Write(buffer, 0, length);
    
                        // Flush the data to the HTML output.
                        Page.Response.Flush();
    
                        //  buffer = new Byte[1024];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        //prevent infinite loop if user disconnects
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Trap the error, if any.
                Page.Response.Write(ex.Message);
            }
            finally
            {
                if (iStream != null)
                {
                    //Close the file.
                    iStream.Close();
                    Page.Response.Close();
                }
    
            }
        }
