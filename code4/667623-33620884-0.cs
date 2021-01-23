     byte[] certBytAr;  // This is the certificate as bianry in a .cer file (no  private key in it - public only) 
     X509Certificate2 cert2 = new X509Certificate2(certBytAr);
     string strToEncrypt = "Public To Private Test StackOverFlow PsudeoCode. Surfs Up at Secret Beach.";
     byte[] bytArToEncrypt = Encoding.UTF8.GetBytes(strToEncrypt);
     SACryptoServiceProvider rsaEncryptor = (RSACryptoServiceProvider)rt2.PublicKey.Key; 
     byte[] dataNowEncryptedArray = rsaEncryptor.Encrypt(bytArToEncrypt, true);
     // done - you now have encrypted bytes 
     // 
      // somewhere elxe ...
     // this should decrpyt it - simulate the destination which will decrypt the data with the private key 
     RSACryptoServiceProvider pk =   // how this is set is complicated 
     // set the private key in the x509 oobject we created way above 
     cert2.PrivateKey = pk; 
     RSACryptoServiceProvider rsaDecryptor = (RSACryptoServiceProvider)cert2.PrivateKey;
     byte[] dataDecrypted = rsaDecryptor.Decrypt(dataNowEncryptedArray, true);
                
     Console.WriteLine(" encrypt 1 Way Intermediate " + BitConverter.ToString(dataDecrypted));
     string strDecodedFinal = Encoding.UTF8.GetString(dataDecrypted);
     if (strDecodedFinal == strToEncrypt)
     {
     }
     else
     {
         Console.WriteLine(" FAILURE OF  ENCRYPTION ROUND TRIP IN SIMPLE TEST (Direction: Public to Private). No Surfing For You ");
      }
