    class EtxReader : IDisposable
    {
        public IEnumerable<string> ReadAll()
        {
            string s;
            while ((s = ReadNext()) != null) yield return s;
        }
        public void Dispose()
        {
            if (socket != null) socket.Dispose();
            socket = null;
            if (backlog != null) backlog.Dispose();
            backlog = null;
            buffer = null;
            encoding = null;
        }
        public EtxReader(Socket socket, Encoding encoding = null, int bufferSize = 4096)
        {
            this.socket = socket;
            this.encoding = encoding ?? Encoding.UTF8;
            this.buffer = new byte[bufferSize];
        }
        private Encoding encoding;
        private Socket socket;
        int index, count;
        byte[] buffer;
        private bool ReadMore()
        {
            index = count = 0;
            int bytes = socket.Receive(buffer);
            if (bytes > 0)
            {
                count = bytes;
                return true;
            }
            return false;
        }
        public const byte ETX = 3;
        private MemoryStream backlog = new MemoryStream();
        public string ReadNext()
        {
            string s;
            if (count == 0)
            {
                if (!ReadMore()) return null;
            }
            // at this point, we expect there to be *some* data;
            // this may or may not include the ETX terminator
            var etxIndex = Array.IndexOf(buffer, ETX, index);
            if (etxIndex >= 0)
            {
                // found another message in the existing buffer
                int len = etxIndex - index;
                s = encoding.GetString(buffer, index, len);
                index = etxIndex + 1;
                count -= (len + 1);
                return s;
            }
            // no ETX in the buffer, so we'll need to fetch more data;
            // buffer the unconsumed data that we have
            backlog.SetLength(0);
            backlog.Write(buffer, index, count);
            bool haveEtx;
            do
            {
                if (!ReadMore())
                {
                    // we had unused data; this must signal an error
                    throw new EndOfStreamException();
                }
                etxIndex = Array.IndexOf(buffer, ETX, index);
                haveEtx = etxIndex >= 0;
                if (!haveEtx)
                {
                    // keep buffering
                    backlog.Write(buffer, index, count);
                }
            } while (!haveEtx);
            // now we have some data in the backlog, and the ETX in the buffer;
            // for convenience, copy the rest of the next message into
            // the backlog
            backlog.Write(buffer, 0, etxIndex);
            s = encoding.GetString(backlog.GetBuffer(), 0, (int)backlog.Length);
            index = etxIndex + 1;
            count -= (etxIndex + 1);
            return s;
        }
    }
