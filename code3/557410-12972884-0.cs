        using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead = 0;
                        while ((bytesRead = memoryStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            requestStream.Write(buffer, 0, bytesRead);
                        }
                    }
