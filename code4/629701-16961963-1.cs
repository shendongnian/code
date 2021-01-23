    public static byte[] ReadChunkedResponse(this WebResponse response)
        {
            byte[] buffer;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream, Encoding.UTF8))
                {
                    var content = new StringBuilder();
                    while (!streamReader.EndOfStream)
                    {
                        content.Append((char)streamReader.Read());
                    }
                    buffer = Encoding.UTF8.GetBytes(content.ToString());
                }
            }
            return buffer;
        }
    }
