    static void AppendTimestamp(string filename,
                                string message,
                                Encoding encoding = null,
                                DateTime? timestamp = null)
    {
         Encoding realEncoding = encoding ?? Encoding.UTF8;
         DateTime realTimestamp = timestamp ?? DateTime.Now;
         using (TextWriter writer = new StreamWriter(filename, true, realEncoding))
         {
             writer.WriteLine("{0:s}: {1}", realTimestamp, message);
         }
    }
