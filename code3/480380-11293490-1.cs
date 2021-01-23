    private string CalculateChecksum(string dataToCalculate)
    {
        byte[] byteToCalculate = Encoding.ASCII.GetBytes(dataToCalculate);
        int checksum = 0;
        foreach (byte chData in byteToCalculate)
        {
            checksum += chData;
        }
        checksum &= 0xff;
        return checksum.ToString("X2");
    }
