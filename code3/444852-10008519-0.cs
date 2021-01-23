        public static long sendMultiPartReq(Stream req, string boundaryString, object[] files, object[] parameters)
        {
            String CRLF = "\r\n";
            byte[] b;
            long contentLength = 0;
            foreach (string[] file in files)
            {
                b = Encoding.UTF8.GetBytes(
                    CRLF + "--" + boundaryString + CRLF +
                    String.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" + CRLF,
                        file[0], Path.GetFileName(file[1])) +
                    "Content-Type: image/png" + CRLF + CRLF);
                contentLength += b.LongLength;
                if (req != null) req.Write(b, 0, b.Length);
                if (File.Exists(file[1]))
                {
                    b = File.ReadAllBytes(file[1]);
                    contentLength += b.LongLength;
                    if (req != null) req.Write(b, 0, b.Length);
                }
                b = Encoding.UTF8.GetBytes(CRLF);
                contentLength += b.LongLength;
                if (req != null) req.Write(b, 0, b.Length);
            }
            foreach (string[] parameter in parameters)
            {
                b = Encoding.UTF8.GetBytes(
                    "--" + boundaryString + CRLF +
                    String.Format("Content-Disposition: form-data; name=\"{0}\"" + CRLF, parameter[0]) +
                    CRLF + parameter[1] + CRLF);
                contentLength += b.LongLength;
                if (req != null) req.Write(b, 0, b.Length);
            }
            b = Encoding.UTF8.GetBytes("--" + boundaryString + "--" + CRLF);
            contentLength += b.LongLength;
            if (req != null) req.Write(b, 0, b.Length);
            return contentLength;
        }
