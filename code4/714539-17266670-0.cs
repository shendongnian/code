        private void AcceptCallback(IAsyncResult AR)
        {
            try
            {
                sckc = sck.EndAccept(AR);
                buffer = new byte[sckc.ReceiveBufferSize];
                sckc.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
            }
            catch
            {
            }
        }
        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                string text = Encoding.ASCII.GetString(buffer);
                MessageBox.Show(text);
                sckc.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
            }
            catch
            {
            }
        }
