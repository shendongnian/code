    using System;
    using System.Security.Cryptography;
    using System.Text;
    public void CreateHash(string sSourceData)
    {
        byte[] sourceBytes;
        byte[] hashBytes;
        //create Bytearray from source data
        sourceBytes = ASCIIEncoding.ASCII.GetBytes(sSourceData);
        // calculate 16 Byte Hashcode
        hashBytes = new MD5CryptoServiceProvider().ComputeHash(sourceBytes);
        string sOutput = ByteArrayToHexString(hashBytes);
     }
    static string ByteArrayToHexString(byte[] arrInput)
    {
        int i;
        StringBuilder sOutput = new StringBuilder(arrInput.Length);
        for (i = 0; i < arrInput.Length - 1; i++)
        {
            sOutput.Append(arrInput[i].ToString("X2"));
        }
        return sOutput.ToString();
    }
