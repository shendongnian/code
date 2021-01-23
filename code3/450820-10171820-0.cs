    private void ReadPdfFile()
        {
            string path = @"C:\Swift3D.pdf";
            WebClient client = new WebClient();
            Byte[] buffer =  client.DownloadData(path);
    
            if (buffer != null)
            {
                Response.ContentType = "application/pdf"; 
                Response.AddHeader("content-length",buffer.Length.ToString()); 
                Response.BinaryWrite(buffer); 
            }
    
        }
