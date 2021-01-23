    public static byte[] DmxDataMessage(Tuple<byte, byte> redTuple, Tuple<byte, byte> greenTuple, Tuple<byte, byte> blueTuple, EnttecDmxController _enttecDmxControllerInterface)
    {
        foreach (KeyValuePair<string, Tuple<byte, byte>> entry in _enttecDmxControllerInterface.DmxChannelsDictionary)
        {
            if (entry.Key.Contains("Red"))
            {
                dmxBuffer[entry.Value.Item1] = redTuple.Item2;
            }
        }
         .......
    }
