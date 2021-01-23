    private void sendButton_Click(object sender, EventArgs e)
    {
        try
        {
            Object objData = messageTextBox.Text;
            byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString() + "\r\n");
            _socket.Send (byData);
        }
        catch(SocketException se)
        {
            MessageBox.Show (se.Message );
        }
    }
