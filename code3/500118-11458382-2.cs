    [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            byte[] bytes = ReadToEnd(file.InputStream);
            using (var mem = new MemoryStream(bytes))
            {
                DocumentStore.DatabaseCommands.PutAttachment("upload/" + DateTime.Now.Second.ToString(CultureInfo.InvariantCulture), null, mem,
                                                              new RavenJObject
                                                              {
                                                                  {"OtherData", "Can Go here"},
                                                                  {"MoreData", "Here"}
                                                              });
            }
            return Content("OK");
        }
        public static byte[] ReadToEnd(Stream stream)
        {
            long originalPosition = 0;
            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }
            try
            {
                var readBuffer = new byte[4096];
                int totalBytesRead = 0;
                int bytesRead;
                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;
                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            var temp = new byte[readBuffer.Length*2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte) nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }
                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
