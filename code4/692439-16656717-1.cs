    StringBuilder outPar;
    string result = "";
    byte[] parbytes = Encoding.Unicode.GetBytes(outPar.ToString());
    foreach(byte parbyte in parbytes)
    {
        result+= parbyte;
    }
    return result;
