    public void listern() {
        while (true) {
            clientSocket = myli.AcceptTcpClient;
            IPAddress tempAddress = ((IPEndPoint)(clientSocket.Client.RemoteEndPoint)).Address;
            UpdateChattextBox(tempAddress.ToString, "Connection accepted from:" + s);     
        }
    }
    
    public void UpdateChattextBox(string address, string message) {
        if ((chattextBox.InvokeRequired == true)) {
            this.invoke(UpdateCattextBox, address, message);
        }
        else {
            chattextBox.Text = tempAddress.ToString;
            chattextBox.AppendText(("Connection accepted from:" + s));
        }
    }
