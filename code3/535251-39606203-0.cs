        public void UploadToFTP(Stream stream, string ftpPath)
        {
            Stream requestStream = null;
            try
            {
                
                Uri uri = GetServerUri(ftpPath);
                FtpWebRequest request = Connect(uri); //here I set user/pwd/etc
                request.UseBinary = true;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.ContentLength = stream.Length;
                requestStream = request.GetRequestStream();
                //Avoid to write zero length files in destiny. 
                //If you have read the stream before for any reason (as a convertion to Bitmap to extract dimensions, for example)
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(requestStream);
            }
            catch (WebException ex)
            {
                //do something
            }
            finally
            {
                if (requestStream != null)
                    requestStream.Close();
            }
        }
