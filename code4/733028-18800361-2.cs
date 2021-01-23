    public void send(string s)
    {
        byte[] NxtMessage = new byte[5 + s.Length];
        NxtMessage[0] = 0x00;
        NxtMessage[1] = 0x09;
        NxtMessage[2] = 0x00;
        NxtMessage[3] = (byte)(s.Length + 1);
        byte[] array = Encoding.ASCII.GetBytes(s);
        for (int ByteCtr = 0; ByteCtr < array.Length; ByteCtr++)
        {
            NxtMessage[4 + ByteCtr] = array[ByteCtr];
        }
        NxtMessage[4 + s.Length] = 0x00;
        NXTSendCommandAndGetReply(NxtMessage);
    }
