    public class SendStuff
        {
            private readonly HttpWebRequest _request;
            private readonly Dictionary<string, string> _kparams;
            private readonly Dictionary<string, FileStream> _kfiles;
            readonly string _boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
    
            public SendStuff(
                HttpWebRequest request, 
                Dictionary<string, string> kparams, 
                Dictionary<string, FileStream> kfiles)
            {
                _request = request;
                _kparams = kparams;
                _kfiles = kfiles;
                _request.ContentType = "multipart/form-data; boundary=" + _boundary;
            }
    
            public void Do()
            {
                
                // Based on HTTP 1.1, if the server can determine the content length, it need not insist on
                // us sending one. If you are talking
                // to a "special" server, construct the headers beforehand, measure their length
                // and identify the file lengths of the files to be sent.
    
                using (var reqStream = _request.GetRequestStream())
                using (var writer = new StreamWriter(reqStream))
                {
                    writer.NewLine = "\r\n";
                    WriteBoundary(writer);
                    WriteParams(writer);
    
                    foreach (var file in _kfiles)
                    {
                        writer.WriteLine("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"", 
                            file.Key, 
                            Path.GetFileName(file.Value.Name));
                        writer.WriteLine("Content-Type: application/octet-stream");
                        writer.WriteLine();
    
                        WriteTheFileContent(reqStream, file.Value);
    
                        WriteBoundary(writer);
                    }
                }
            }
    
            private static void WriteTheFileContent(Stream reqStream, Stream fileStream)
            {
                int bytesRead;
                var buffer = new byte[4096];
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    reqStream.Write(buffer, 0, bytesRead);
            }
    
            private void WriteParams(StreamWriter writer)
            {
                foreach (var param in _kparams)
                {
                    writer.WriteLine("Content-Disposition: form-data; name=\"{0}\"", param.Key);
                    writer.WriteLine();
                    writer.WriteLine(param.Value);
                    WriteBoundary(writer);
                }
            }
    
            private void WriteBoundary(TextWriter writer)
            {
                writer.WriteLine("\r\n--{0}\r\n", _boundary);
            }
        }
