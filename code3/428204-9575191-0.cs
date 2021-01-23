        ...
        using (var cs = new CryptoStream(ms, crypt.CreateEncryptor(), CryptoStreamMode.Write))
        {
            cs.Write(clearData, 0, clearData.Length);
            cs.FlushFinalBlock();
            cs.Close();
        }
        ms.Close();
        encryptedData = ms.ToArray();
        ...
