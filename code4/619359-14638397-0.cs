    static Int32 GetCharPos(StreamReader s)
    {
        var ia = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField;
        Int32 charpos = (Int32)s.GetType().InvokeMember("charPos", ia, null, s, null);
        Int32 charlen = (Int32)s.GetType().InvokeMember("charLen", ia, null, s, null);
        return (Int32)s.BaseStream.Position - charlen + charpos;
    }
    static void Appsert(string data, string precedingEntry = null)
    {
        if (precedingEntry == null)
        {
            using (var filestream = new FileStream(dataPath, FileMode.Append))
            using (var tw = new StreamWriter(filestream))
            {
                tw.WriteLine(data);
                return;
            }
        }
        int seekPos = -1;
        using (var readstream = new FileStream(dataPath, 
            FileMode.Open, FileAccess.Read, FileShare.Write))
        using (var writestream = new FileStream(dataPath, 
            FileMode.Open, FileAccess.Write, FileShare.Read))
        using (var tr = new StreamReader(readstream))
        {
            while (seekPos == -1)
            {
                var line = tr.ReadLine();
                if (line == precedingEntry)
                    seekPos = GetCharPos(tr);
                else if (tr.EndOfStream)
                    seekPos = (int)readstream.Length;
            }
            
            writestream.Seek(seekPos, SeekOrigin.Begin);
            readstream.Seek(seekPos, SeekOrigin.Begin);
            int readLength = 0;
            var readBuffer = new byte[4096];
            var writeBuffer = new byte[4096];
            var writeData = tr.CurrentEncoding.GetBytes(data + Environment.NewLine);
            int writeLength = writeData.Length;
            writeData.CopyTo(writeBuffer, 0);
            while (true & writeLength > 0)
            {
                readLength = readstream.Read(readBuffer, 0, readBuffer.Length);
                writestream.Write(writeBuffer, 0, writeLength);
                var tmp = writeBuffer;
                writeBuffer = readBuffer;
                writeLength = readLength;
                readBuffer = tmp;
            }                
        }
    }
