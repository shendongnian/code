    public static bool IsUrlImage(string url)
    {
        try
        {
            var request = WebRequest.Create(url);
            request.Timeout = 5000;
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (!response.ContentType.Contains("text/html"))
                    {
                        using (var br = new BinaryReader(responseStream))
                        {
                            // e.g. test for a JPEG header here
                            var soi = br.ReadUInt16();  // Start of Image (SOI) marker (FFD8)
                            var jfif = br.ReadUInt16(); // JFIF marker (FFE0)
                            return soi == 0xd8ff && jfif == 0xe0ff;
                        }
                    }
                }
            }
        }
        catch (WebException ex)
        {
            Trace.WriteLine(ex);
            throw;
        }
        return false;
    }
