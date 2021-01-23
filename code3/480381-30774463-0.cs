    private bool CheckChecksum(string data)
    {
       bool isValid =false
       byte[] byteToCalculate = Encoding.ASCII.GetBytes(dataToCalculate);
       int checkSum = 0;
       for ( int i=i i<byteToCalculate.Length;i++)
       {
          checkSum += byteToCalculate[i];
       }
       checksum &= 0xff;
      if (checksum == byteToCalculate[ChecksumPlace]
      {
       return true
      }
      else
      {
      return  false
      }
    }
