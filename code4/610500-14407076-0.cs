    try
    {
        await socket.ConnectTaskAsync("www.google.com", 80);
        socket.Send(bytesToSend);
        var len = await socket.ReceiveTaskAsync(buf, 0, buf.Length);
        var str = Encoding.UTF8.GetString(buf, 0, len);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
---
    public static class SocketExtensions
    {
        public static Task ConnectTaskAsync(this Socket socket, string host, int port)
        {
            return Task.Factory.FromAsync(
                         socket.BeginConnect(host, port, null, null),
                         socket.EndConnect);
        }
        public static Task<int> ReceiveTaskAsync(this Socket socket, 
                                                byte[] buffer, 
                                                int offset, 
                                                int count)
        {
            return Task.Factory.FromAsync<int>(
               socket.BeginReceive(buffer, offset, count, SocketFlags.None, null, socket),
               socket.EndReceive);
        }
    }
