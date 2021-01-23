                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(3072);
                byte[] sshrsa_bytes = Encoding.Default.GetBytes("ssh-rsa");
                byte[] n = RSA.ExportParameters(false).Modulus;
                byte[] e = RSA.ExportParameters(false).Exponent;
                string buffer64;
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(ToBytes(sshrsa_bytes.Length), 0, 4);
                    ms.Write(sshrsa_bytes, 0, sshrsa_bytes.Length);
                    ms.Write(ToBytes(e.Length), 0, 4);
                    ms.Write(e, 0, e.Length);
                    ms.Write(ToBytes(n.Length+1), 0, 4); //Remove the +1 if not Emulating Putty Gen
                    ms.Write(new byte[] { 0 }, 0, 1); //Add a 0 to Emulate PuttyGen
                    ms.Write(n, 0, n.Length);
                    ms.Flush();
                    buffer64 = Convert.ToBase64String(ms.ToArray());
                }
