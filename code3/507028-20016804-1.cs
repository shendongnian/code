    public class RijndaelSimple
        {
            const string iv = "56666852251557009888889955123458";
            const string key = "edrtjfjfjlldldld";
    
            static public String EncryptRJ256(string plainText)
            {
                var encoding = new UTF8Encoding();
                var Key = encoding.GetBytes(key);
                var IV = encoding.GetBytes(iv);
                byte[] encrypted;
    
                using (var rj = new RijndaelManaged())
                {
                    try
                    {
                        rj.Padding = PaddingMode.PKCS7;
                        rj.Mode = CipherMode.CBC;
                        rj.KeySize = 256;
                        rj.BlockSize = 256;
                        rj.Key = Key;
                        rj.IV = IV;
    
                        var ms = new MemoryStream();
    
                        using (var cs = new CryptoStream(ms, rj.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                        {
                            using (var sr = new StreamWriter(cs))
                            {
                                sr.Write(plainText);
                            }
                            encrypted = ms.ToArray();
                        }
                    }
                    finally
                    {
                        rj.Clear();
                    }
                }
    
                return Convert.ToBase64String(encrypted);
            }
    
            static public String DecryptRJ256(string input)
            {
                byte[] cypher = Convert.FromBase64String(input);
    
                var sRet = "";
    
                var encoding = new UTF8Encoding();
                var Key = encoding.GetBytes(key);
                var IV = encoding.GetBytes(iv);
    
                using (var rj = new RijndaelManaged())
                {
                    try
                    {
                        rj.Padding = PaddingMode.PKCS7;
                        rj.Mode = CipherMode.CBC;
                        rj.KeySize = 256;
                        rj.BlockSize = 256;
                        rj.Key = Key;
                        rj.IV = IV;
                        var ms = new MemoryStream(cypher);
    
                        using (var cs = new CryptoStream(ms, rj.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                        {
                            using (var sr = new StreamReader(cs))
                            {
                                sRet = sr.ReadLine();
                            }
                        }
                    }
                    finally
                    {
                        rj.Clear();
                    }
                }
    
                return sRet;
            }
    
        }
