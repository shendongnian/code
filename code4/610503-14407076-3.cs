    try
    {
        await socket.ConnectTaskAsync("www.google.com", 80);
        await socket.SendTaskAsync(bytesToSend);
        
        byte[] buf = new byte[0x8000];
        var bytesRead = await socket.ReceiveTaskAsync(buf, 0, buf.Length);
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
        public static Task SendTaskAsync(this Socket socket, byte[] buffer)
        {
            return Task.Factory.FromAsync<int>(
                  socket.BeginSend(buffer,0,buffer.Length,SocketFlags.None, null, socket),
                  socket.EndSend);
        }
    }
