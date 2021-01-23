    public static string FoldLines(string value, int max, string newline = "\r\n")
    {
        var lines = value.Split(new string[] { newline }, System.StringSplitOptions.RemoveEmptyEntries);
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
                    var offset = 0; //current offset position
                    var count = max; //characters to take
                    while (offset + count < len)
                    {
                        ms.Write(bytes, offset, count);
                        ms.Write(crlfs, 0, crlfs.Length);
                        offset += count;
                        count = max - 1;
                    }
                    count = len - offset; //remaining characters
                    if (count > 0)
                    {
                        ms.Write(bytes, offset, count);
                        ms.Write(crlf, 0, crlf.Length);
                    }
                }
            }
    
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
