    static void DecryptFile(string sInputFilename, string sOutputFilename, string sKey)
    {
        DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
        DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
        DES.Mode = CipherMode.CFB;
        DES.Padding = PaddingMode.ISO10126;
        FileStream fsread = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
        ICryptoTransform desdecrypt = DES.CreateDecryptor();
        CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);
        FileStream fsDecrypted = new FileStream(sOutputFilename,FileMode.Create,FileAccess.Write);
        cryptostreamDecr.CopyTo(fsDecrypted);
        fsDecrypted.Flush();
        fsDecrypted.Close();
    }
