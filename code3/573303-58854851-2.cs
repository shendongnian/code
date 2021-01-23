    public static string DecryptTest(string cipherString, string key, bool useHashing)
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);
                byte[] initVectorBytes = Encoding.ASCII.GetBytes("$secure#");
    
                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                }
                else
                     keyArray = UTF8Encoding.UTF8.GetBytes(key);
    
                var tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.CBC;  // which is default     
                tdes.Padding = PaddingMode.PKCS7;  // which is default
                tdes.IV = initVectorBytes;
    
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
    
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
