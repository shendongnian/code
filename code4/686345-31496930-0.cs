    PeerFinder.AlternateIdentities["Bluetooth:PAIRED"] = "";
            var available_devices = await PeerFinder.FindAllPeersAsync();
            HostName hostName = null;
            for (int i = 0; i < available_devices.Count; i++)
            {
                PeerInformation dispositivo = available_devices[i];
                if (dispositivo.DisplayName.ToUpper() == /*Name of you device */)
                {
                    hostName = dispositivo.HostName;
                    break;
                }
            }
            if (hostName != null)
            {
                var socket = new StreamSocket();
                await socket.ConnectAsync(hostName, "1");
            }
