    public void Send(byte[] data, int index, int length)
    {
        //add data as state
        socket.BeginSend(BitConverter.GetBytes(length), 0, 4, SocketFlags.None, sendCallback, data);
    }
    private void sendCallback(IAsyncResult ar)
    {
        try
        {
            int sent = socket.EndSend(ar); ( errrors here )
            // check if data was attached.
            if (ar.AsyncState != null)
            {
                byte[] buffer = (byte[])ar.AsyncState;
                socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, sendCallback, null);
                return;
            }
            if (OnSend != null)
            {
                OnSend(this, sent);
            }
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.ToString());
            return;
        }
    }
