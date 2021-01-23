    public byte[] ToBinary(string stringPassed)
    {
       System.Text.ASCIIEncoding  encoding = new System.Text.ASCIIEncoding();
       return encoding.GetBytes(stringPassed);
    }
