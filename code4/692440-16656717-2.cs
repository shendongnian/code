    StringBuilder outPar;
    string result = "";
    byte[] parbytes = System.Text.Encoding.Unicode.GetBytes(outPar.ToString());
    foreach(byte parbyte in parbytes)
    {
        result+= Convert.ToChar(parbyte);
    }
    return result;
