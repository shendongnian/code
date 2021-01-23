            var response = await HttpWebRequest.Create(url).GetResponseAsync();
            List<Byte> allBytes = new List<byte>();
            using (Stream imageStream = response.GetResponseStream())
            {
                byte[] buffer = new byte[4000];
                int bytesRead = 0;
                while ((bytesRead = await imageStream.ReadAsync(buffer, 0, 4000)) > 0)
                {
                    allBytes.AddRange(buffer.Take(bytesRead));
                }
            }
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                        "localfile.png", CreationCollisionOption.FailIfExists);
            await FileIO.WriteBytesAsync(file, allBytes.ToArray()); 
