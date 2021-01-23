     if (lastSnapshot != null)//writableBitmap object lastSnapshot
            {
                using (var pngStream = GetPngStream(lastSnapshot))//return Stream type 
                using (var file = File.Create(Path.Combine("ImageFolder", "ImageName.png")))
                {
                    byte[] binaryData = new Byte[pngStream.Length];
                    long bytesRead = pngStream.Read(binaryData, 0, (int)pngStream.Length);
                    file.Write(binaryData, 0, (int)pngStream.Length);
                    file.Flush();
                    file.Close();
                }
            }
