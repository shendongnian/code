        DateTime lastUpdate = DateTime.MinValue;
        while (!myStreamReader.EndOfStream)
        {
            _packet = myStreamReader.ReadLine();
            //if (_packet.StartsWith("Frame Number: "))
            //{
            //    string[] arr = _packet.Split(' ');
            //    _test = int.Parse(arr[2]);
            //    _packetsCount++;
            //}
            // If more than one second
            if((DateTime.Now - lastUpdate).TotalMilliseconds > 1000)
            {
                lastUpdate = DateTime.Now;
                OnPacketProgress(_packetsCount++);
            }
        }
