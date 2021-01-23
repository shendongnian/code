    [WebGet(UriTemplate = "file/{id}")]
            public Stream GetPdfFile(string id)
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/txt";
                FileStream f = new FileStream("C:\\Test.txt", FileMode.Open);
                int length = (int)f.Length;
                WebOperationContext.Current.OutgoingResponse.ContentLength = length;
                byte[] buffer = new byte[length];
                int sum = 0;
                int count;
                while((count = f.Read(buffer, sum , length - sum)) > 0 )
                {
                    sum += count;
                }
                f.Close();
                return new MemoryStream(buffer); 
            }
