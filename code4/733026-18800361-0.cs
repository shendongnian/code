     private string NXTSendCommandAndGetReply(byte[] Command)
        {
            string r = "";
            Byte[] MessageLength = { 0x00, 0x00 };
            MessageLength[0] = (byte)Command.Length;
            BluetoothConnection.Write(MessageLength, 0, MessageLength.Length);
            BluetoothConnection.Write(Command, 0, Command.Length);
            int length = BluetoothConnection.ReadByte() + 256 * BluetoothConnection.ReadByte();
            for (int i = 0; i < length; i++)
                r += BluetoothConnection.ReadByte().ToString("X2");
            return r;
        }
