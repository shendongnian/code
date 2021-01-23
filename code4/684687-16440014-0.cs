    public bool ReadData(byte[] responseBytes, int bytesExpected, int timeOut)
    {
        MySerialPort.ReadTimeout = timeOut;
        int offset = 0, bytesRead;
        while(bytesExpected > 0 &&
          (bytesRead = MySerialPort.Read(responseBytes, offset, bytesExpected)) > 0)
        {
            offset += bytesRead;
            bytesExpected -= bytesRead;
        }
        return bytesExpected == 0;
    }
