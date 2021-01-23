    /// Convert a string to a byte array.  NOTE: Normally we'd create a Byte Array from a string using an ASCII encoding (like so). 
    //      System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding(); 
    //      return encoding.GetBytes(str); 
    // However, this results in character values that cannot be passed in a URL.  So, instead, I just 
    // lay out all of the byte values in a long string of numbers (three per - must pad numbers less than 100). 
    public byte[] StrToByteArray(string str)
