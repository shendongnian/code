    void webClient_OpenWriteCompleted(object sender, OpenWriteCompletedEventArgs e)
            {
                if (e.Error == null)
                {
                    Stream responseStream = e.Result as Stream;                
                    dynamic obj = e.UserState;
                    MemoryStream memoryStream = obj.Stream as MemoryStream;
                    string fileName = obj.FileName;
                    if (responseStream != null && memoryStream != null)
                    {
                        string headerTemplate = string.Format("-----------------------------{0}\r\n", _boundaryNo);
    
                        memoryStream.Position = 0;
                        byte[] byteArr = memoryStream.ToArray();
                        string data = headerTemplate + string.Format("Content-Disposition: form-data; name=\"pic\"; filename=\"{0}\"\r\nContent-Type: application/octet-stream\r\n\r\n", fileName);
                        byte[] header = Encoding.UTF8.GetBytes(data);
                        responseStream.Write(header, 0, header.Length);
    
                        responseStream.Write(byteArr, 0, byteArr.Length);
                        header = Encoding.UTF8.GetBytes("\r\n");
                        responseStream.Write(byteArr, 0, byteArr.Length);
    
                        byte[] trailer = System.Text.Encoding.UTF8.GetBytes(string.Format("-----------------------------{0}--\r\n", _boundaryNo));
                        responseStream.Write(trailer, 0, trailer.Length);                    
                    }
                    memoryStream.Close();
                    responseStream.Close();
                }
            }
