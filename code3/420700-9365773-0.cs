    class Program
    {
        static void Main()
        {
            DownloadClient("http://itu.dk/people/janv/mufc_abc.jpg", "mufc_abc.jpg");
        }
    
        public static void DownloadClient(string uri, string fileName)
        {
            using (var client = new WebClient())
            {
                using (var stream = client.OpenRead(uri))
                {
                    // work with chunks of 2KB => adjust if necessary
                    const int chunkSize = 2048;
                    var buffer = new byte[chunkSize];
                    using (var output = File.OpenWrite(fileName))
                    {
                        int bytesRead;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }
    }
