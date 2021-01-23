    private void UdpListener()
        {
            _iep = new IPEndPoint(IPAddress.Any, 9050);
            _listener = new UdpClient(_iep);
            while (true)
            {
                Stream inputStream = new MemoryStream(_listener.Receive(ref _iep));
                dynamic msg = _service.Deserialize<object>(inputStream);
                Received(msg.Payload);
            }
        }
