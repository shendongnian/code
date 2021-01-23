    List<TransportResponse> lstResponse = new List<TransportResponse>();
    using (var client = new SftpClient(connectionInfo))
      {
              try
              {
                        Console.WriteLine("Connecting to " + connectionInfo.Host + " ...");
                        client.Connect();
                        Console.WriteLine("Connected to " + connectionInfo.Host + " ...");
               }
               catch (Exception ex)
               {
                        Console.WriteLine("Could not connect to "+ connectionInfo.Host +" server. Exception Details: " + ex.Message);
               }
               if (client.IsConnected)
               {
                        var files = client.ListDirectory(transport.SourceFolder);
                        lstResponse = downloadFilesInDirectory(files, client);
                        client.Disconnect();
                }
                else
                {
                        Console.WriteLine("Could not download files from "+ transport.TransportIdentifier +" because client was not connected.");
                 }
       }
  
    private static List<TransportResponse> downloadFilesInDirectory(IEnumerable<SftpFile> files, SftpClient client)
        {
            List<TransportResponse> lstResponse = new List<TransportResponse>();
            foreach (var file in files)
            {
                if (!file.IsDirectory)
                {
                    if (file.Name != "." && file.Name != "..")
                    {
                        if (!TransportDAL.checkFileExists(file.Name, file.LastWriteTime))
                        {
                            using (MemoryStream fs = new MemoryStream())
                            {
                                try
                                {
                                    Console.WriteLine("Reading " + file.Name + "...");
                                    client.DownloadFile(file.FullName, fs);
                                    fs.Seek(0, SeekOrigin.Begin);
                                    lstResponse.Add(new TransportResponse { fileName = file.Name, fileTimeStamp = file.LastWriteTime, fileStream = new MemoryStream(fs.GetBuffer()) });
                                }
                                catch(Exception ex)
                                {
                                    Console.WriteLine("Error reading File. Exception Details: " + ex.Message);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("File was downloaded previously");
                        }
                    }
                }
                else
                {
                    if (file.Name != "." && file.Name != "..")
                    {
                        lstResponse.Add(new TransportResponse { directoryName = file.Name,lstTransportResponse = downloadFilesInDirectory(client.ListDirectory(file.Name), client) });
                    }                
                }
            }
            return lstResponse;
        }
