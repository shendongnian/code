    private int read(int mailbox)
    {
        byte[] NxtMessage = { 0x00, 0x13, 0x00, 0x00, 0x01 };
        NxtMessage[2] = (byte)(mailbox - 1 + 10);
        string r = NXTSendCommandAndGetReply(NxtMessage);
        return Convert.ToInt32((r[10] + "" + r[11]), 16);
    }
