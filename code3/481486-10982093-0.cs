    public void FileUpload(string fileName, Stream fileStream)
            {
    
                FileStream fileToupload = new FileStream("c:\\FileUpload\\" + fileName, FileMode.Create);
    
                byte[] bytearray = new byte[10000];
                int bytesRead, totalBytesRead = 0;
                do
                {
                    bytesRead = fileStream.Read(bytearray, 0, bytearray.Length);
                    totalBytesRead += bytesRead;
                } while (bytesRead > 0);
    
                fileToupload.Write(bytearray, 0, bytearray.Length);
                fileToupload.Close();
                fileToupload.Dispose();
    
            }
    [ServiceContract]
        public interface IImageUpload
        {
            [OperationContract]
            [WebInvoke(Method = "POST", UriTemplate = "FileUpload/{fileName}")]
            void FileUpload(string fileName, Stream fileStream);
    
        }
