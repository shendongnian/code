            using (var socket = new StreamSocket())
            {
                socket.Control.KeepAlive = false;
                socket.Control.NoDelay = false;
                await socket.ConnectAsync(new HostName("192.168.1.1"), "5555", SocketProtectionLevel.PlainSocket);
                using (var writer = new DataWriter(socket.OutputStream))
                {
                    writer.UnicodeEncoding = UnicodeEncoding.Utf8;
                    writer.WriteString("yea!");
                    await writer.StoreAsync();
                }
            }
