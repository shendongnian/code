    MemoryStream msDecrypt = null;
    CryptoStream csDecrypt = null;
    try
    {    
        msDecrypt = new MemoryStream();
        csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write);
        
        csDecrypt.Write(eop.m_Ciphertext, 0, eop.m_Ciphertext.Length);
        csDecrypt.FlushFinalBlock();
        decrypted = msDecrypt.ToArray();
    }
    finally
    {
        if (csDecrypt != null)
        {
            csDecrypt.Dispose();
        }
        else if (msDecrypt != null)
        {
            msDecrypt.Dispose();
        }
    }
