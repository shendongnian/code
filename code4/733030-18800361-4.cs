    private string read_txt(int mailbox)
    {
        byte[] NxtMessage = { 0x00, 0x13, 0x00, 0x00, 0x01 };
        NxtMessage[2] = (byte)(mailbox - 1 + 10);
        string r = NXTSendCommandAndGetReply(NxtMessage);
        int a = 0;
        string recieved = "";
        for (int i = 10; ; i += 2)
        {
            a = int.Parse(r[i] + "" + r[i+1], System.Globalization.NumberStyles.HexNumber);
            if (a == 0)
                break;
            recieved += char.ConvertFromUtf32(a);
        }
        return r;
    }
