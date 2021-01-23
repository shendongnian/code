            //Decrypt the encrypted text from a hardcoded string literal
            var encryptedBytes = Convert.FromBase64String("cc1zurZinx4yxeSB0XDzVziEUNJlFXsLzD2p9TWnxEc=");
            var testStringDecrypted = Encoding.Unicode.GetString(decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
            decryptor = provider.CreateDecryptor(keyBytes, ivBytes);
            //Decrypt the encrypted text from the string result of the encryption process
            var encryptedBytes2 = Convert.FromBase64String(testStringEncrypted);
            var testStringDecrypted2 = Encoding.Unicode.GetString(decryptor.TransformFinalBlock(encryptedBytes2, 0, encryptedBytes2.Length));
