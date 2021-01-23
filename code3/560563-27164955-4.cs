        public static string FoldLines(this string value, int max, string newline = "\r\n")
        {
            var lines = value.Split(new string[]{newline}, System.StringSplitOptions.RemoveEmptyEntries);
            using (var ms = new System.IO.MemoryStream(value.Length))
            {
                var crlf = Encoding.UTF8.GetBytes(newline); //CRLF
                var crlfs = Encoding.UTF8.GetBytes(string.Format("{0} ", newline)); //CRLF and SPACE
                foreach (var line in lines)
                {
                    var bytes = Encoding.UTF8.GetBytes(line);
                    var len = Encoding.UTF8.GetByteCount(line);
                    if (len <= max)
                    {
                        ms.Write(bytes, 0, len);
                        ms.Write(crlf, 0, crlf.Length); 
                    }
                    else
                    {
                        var blen = len / max; //calculate block length
                        var rlen = len % max; //calculate remaining length
                        var b = 0;
                        while (b < blen)
                        {
                            ms.Write(bytes, (b++) * max, max);
                            ms.Write(crlfs, 0, crlfs.Length); 
                        }
                        if (rlen > 0)
                        {
                            ms.Write(bytes, blen * max, rlen);
                            ms.Write(crlf, 0, crlf.Length);
                        }
                    }
                }
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
