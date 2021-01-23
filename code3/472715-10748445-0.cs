    using (var client = new WebClient())
            {
                using (var stream = client.OpenRead(uri))
                {
                    const int chunkSize = 100;
                    var buffer = new byte[chunkSize];
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        //check response here
                    }
                }
            }
