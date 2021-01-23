    private void btnSend_Click(object sender, EventArgs e)
        {
            TcpClient socketForServer;
                try
                {
                    socketForServer = new TcpClient(txtBxDestIP.Text.Trim(), 56009);
                }
                catch
                {
                    MessageBox.Show("Failed to connect to server at " + txtBxDestIP.Text.Trim() + ":999", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NetworkStream networkStream = socketForServer.GetStream();
                StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);
                try
                {
                    string InputString;
                    InputString = Network.GetLocalIPAddress() + ": " + txtBxData.Text;
                    streamWriter.Write(InputString);
                    streamWriter.Flush();
                    socketForServer.Close();
                    txtBxHistory.Text += "\r\nMe: " + txtBxData.Text.Trim();
                    txtBxData.Clear();
                }
                catch
                {
                    MessageBox.Show("Exception reading from Server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                streamWriter.Close();
                networkStream.Close();
                socketForServer.Close();
        }
