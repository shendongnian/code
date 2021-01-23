        public static string EncryptString(string message, string KeyString, string IVString)
        {
            byte[] Key = ASCIIEncoding.UTF8.GetBytes(KeyString);
            byte[] IV = ASCIIEncoding.UTF8.GetBytes(IVString);
            string encrypted = null;
            RijndaelManaged rj = new RijndaelManaged();
            rj.Key = Key;
            rj.IV = IV;
            rj.Mode = CipherMode.CBC;
            try
            {
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, rj.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(message);
                        sw.Close();
                    }
                    cs.Close();
                }
                byte[] encoded = ms.ToArray();
                encrypted = Convert.ToBase64String(encoded);
                ms.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: {0}", e.Message);
            }
            finally
            {
                rj.Clear();
            }
            return encrypted;
        }
