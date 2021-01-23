    public class DownloadHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // send the file in 10k chunks -- should help with mem consumption
            Stream stream = null;
            byte[] buffer = new Byte[10000];
            // Length of the file:
            int length;
            // Total bytes to read:
            long dataToRead;
            try
            {
                CaseService svc = new CaseService();
                // Retrieve the attachment
                DownloadFileResponse response = svc.RetrieveAttachment(context.Request["f"].ToString(), context.Request["u"].ToString());
                AttachmentContract file = response.Attachment;
                stream = new MemoryStream(response.FileBytes);
                // Total bytes to read:
                dataToRead = Convert.ToInt64(file.FileSize);
                context.Response.ContentType = "application/octet-stream";
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.FileName);
                // Read the bytes.
                while (dataToRead > 0)
                {
                    // Verify that the client is connected.
                    if (context.Response.IsClientConnected)
                    {
                        // Read the data in buffer.
                        length = stream.Read(buffer, 0, 10000);
                        // Write the data to the current output stream.
                        context.Response.OutputStream.Write(buffer, 0, length);
                        // Flush the data to the HTML output.
                        context.Response.Flush();
                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        //prevent infinite loop if user disconnects
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception)
            {
                // Trap the error, if any.
                throw;
            }
            finally
            {
                if (stream != null)
                {
                    //Close the file.
                    stream.Close();
                }
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
