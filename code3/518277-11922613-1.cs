    private static DeviceCommand Deserialize(byte[] input)
    {
        DeviceCommand result = new DeviceCommand();
        using (var ms = new MemoryStream())
        {
            result.Address = ms.ReadByte();
            result.Length = ms.ReadByte();
    
            //assuming .Length contains the number of statusElements:
            result.statusElemetns = new StatusElement[result.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result.statusElements[i].statusPart1 = ms.ReadByte();
                result.statusElements[i].statusPart2 = ms.ReadByte();
            }
        }
        return result;
    }
