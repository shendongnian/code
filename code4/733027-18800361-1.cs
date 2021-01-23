    private void send(int a)
    {
        byte[] NxtMessage = { 0x00, 0x09, 0x00, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00 };
        NxtMessage[2] = (byte)(0);
        int tmp = (int)a;
        for (int ByteCtr = 0; ByteCtr <= 3; ByteCtr++)
        {
            NxtMessage[4 + ByteCtr] = (byte)tmp;
            tmp >>= 8;
        }
        NXTSendCommandAndGetReply(NxtMessage);
    }
