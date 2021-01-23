    private void emptyStreamBuffer()
    {
        while (ns.DataAvailable)
            ns.ReadByte();
    }
>
    private string readLine()
    {
        int i = 0; 
        for (byte b = (byte) ns.ReadByte(); b != '\n'; b = (byte) ns.ReadByte())
            buffer[i++] = b;
