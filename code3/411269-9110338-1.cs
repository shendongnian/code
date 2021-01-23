    public static string Encrypt(string password)
    {
        string myPassword = string.Empty;
        if (!string.IsNullOrEmpty(password))
        {
            myPassword = password;
            byte[] Value = System.Text.Encoding.UTF8.GetBytes(myPassword);
            SymmetricAlgorithm mCSP = new RijndaelManaged();
            mCSP.Key = _key;
            mCSP.IV = _initVector;
            using (ICryptoTransform ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV))
            {
                System.IO.MemoryStream ms = null;
                try
                {
                    ms = new System.IO.MemoryStream()
                    var tmp = ms;
                    using (CryptoStream cs = new CryptoStream(ms, ct, 
                                                           CryptoStreamMode.Write))
                    {
                        ms = null;
                        cs.Write(Value, 0, Value.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                        myPassword = Convert.ToBase64String(tmp.ToArray());
                    }
                }
                finally
                {
                    if(ms != null)
                        ms.Dispose();
                }
            }
        }
        return myPassword;
    }
