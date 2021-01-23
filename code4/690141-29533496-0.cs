            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageURL);
            imageRequest.Method = "GET";
            HttpWebResponse imageResponse = (HttpWebResponse)imageRequest.GetResponse();
            using (Stream inputStream = imageResponse.GetResponseStream())
            {
                using (Stream outputStream = File.OpenWrite("SonyCamera.jpg"))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }
            }
        }
`
