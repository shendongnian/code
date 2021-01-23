    private async void button1_Click(object sender, EventArgs e)
    {
        var listOfIps = new List<string> { "192.168.168.193", "192.168.168.221" };
        await Task.WhenAll(listOfIps.Select(ip => ReadFromAddress(ip)));
    }
    private async Task ReadFromAddress(string address)
    {
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), 4001);
        Socket client = new Socket(AddressFamily.InterNetwork,
                                   SocketType.Stream, ProtocolType.Tcp);
        sockets.Add(client);
        await client.ConnectTaskAsync(remoteEP);
        await ReadAsync(client);
    }
