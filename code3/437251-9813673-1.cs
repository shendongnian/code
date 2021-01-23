    List<byte> byteList = new List<byte>()
    {
        0x01, 0x09, 0x01, 0x02, 0x08, 0x02, 0x03, 0x07, 0x03
    };
    var completeObjects = Enumerable.Range(0, byteList.Count / 3).Select(index =>
        new
        {
            Address = byteList[index * 3],
            OldValue = byteList[index * 3 + 1],
            NewValue = byteList[index * 3 + 2],
        });
