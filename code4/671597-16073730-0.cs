    public string CalcCRC16(string strInput) {
        ushort crc = 0xFFFF;
        byte[] data = GetBytesFromHexString(strInput);
        for (int i = 0; i < data.Length; i++) {
            crc ^= (ushort)(data[i] << 8);
            for (int j = 0; j < 8; j++) {
                if ((crc & 0x8000) > 0)
                    crc = (ushort)((crc << 1) ^ 0x1021);
                else
                    crc <<= 1;
            }
        }
        return crc.ToString("X4");
    }
    public Byte[] GetBytesFromHexString(string strInput) {
        Byte[] bytArOutput = new Byte[] { };
        if (!string.IsNullOrEmpty(strInput) && strInput.Length % 2 == 0) {
            SoapHexBinary hexBinary = null;
            try {
                hexBinary = SoapHexBinary.Parse(strInput);
                if (hexBinary != null) {
                    bytArOutput = hexBinary.Value;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        return bytArOutput;
    }
