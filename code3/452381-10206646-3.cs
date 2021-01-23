    using System.Net;
    using System.Net.Sockets;
    static void Main(string[] args)
    {
        string Hostname = "www.website.com";
        TcpClient Client = new TcpClient(Hostname, 80);
        Client.Client.Send(new ASCIIEncoding().GetBytes("POST / HTTP/1.1\nHost: "+Hostname+"\nConnection: close\n\n"));
        Client.Close();
    }
