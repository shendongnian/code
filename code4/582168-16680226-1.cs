                TripleDESCryptoServiceProvider cp = new TripleDESCryptoServiceProvider();
                MemoryStream m = new MemoryStream(Convert.FromBase64String(Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(plainText))));
                CryptoStream cs = new CryptoStream(m, cp.CreateEncryptor(cp.Key, cp.IV), CryptoStreamMode.Read);
                cp.Key = Convert.FromBase64String("the key value from above");
                cp.IV = Convert.FromBase64String("the iv value from above");
                string key = Convert.ToBase64String(cp.Key);
                string iv = Convert.ToBase64String(cp.IV);
                List<byte> r = new List<byte>();
                int x = 0;
                for (; x > -1; )
                {
                    x = cs.ReadByte();
                    if (x > -1)
                        r.Add((byte)x);
                }
                byte[] y = r.ToArray();
                string cypherText = Convert.ToBase64String(y);
