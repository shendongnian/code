    private byte[] Serialize()
    {
        using (var ms = new MemoryStream())
        {
            ms.WriteByte(Address);
            ms.WriteByte(Length);
            foreach (var element in statusElements)
            {
                ms.WriteByte(element.statusPart1);
                ms.WriteByte(element.statusPart2);
            }
            return ms.ToArray();
        }
    }
