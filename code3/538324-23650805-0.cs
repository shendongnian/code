    public static CryptographicKey GetCryptographicPublicKeyFromCert(string strCert)
        {
            int length;
            CryptographicKey CryptKey = null;
            byte[] bCert = Convert.FromBase64String(strCert);
            // Assume Cert contains RSA public key 
            // Find matching OID in the certificate and return public key
            byte[] rsaOID = EncodeOID("1.2.840.113549.1.1.1");
            int index = FindX509PubKeyIndex(bCert, rsaOID, out length);
            // Found X509PublicKey in certificate so copy it.
            if (index > -1)
            {
                byte[] X509PublicKey = new byte[length];
                Array.Copy(bCert, index, X509PublicKey, 0, length);
                AsymmetricKeyAlgorithmProvider AlgProvider = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithmNames.RsaPkcs1);
                CryptKey = AlgProvider.ImportPublicKey(CryptographicBuffer.CreateFromByteArray(X509PublicKey));
            }
            return CryptKey;
        }
        static int FindX509PubKeyIndex(byte[] Reference, byte[] value, out int length)
        {
            int index = -1;
            bool found;
            length = 0;
            for (int n = 0; n < Reference.Length; n++)
            {
                if ((Reference[n] == value[0]) && (n + value.Length < Reference.Length))
                {
                    index = n;
                    found = true;
                    for (int m = 1; m < value.Length; m++)
                    {
                        if (Reference[n + m] != value[m])
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found) break;
                    else index = -1;
                }
            }
            if (index > -1)
            {
                // Find outer Sequence
                while (index > 0 && Reference[index] != 0x30) index--;
                index--;
                while (index > 0 && Reference[index] != 0x30) index--;
            }
            if (index > -1)
            {
                // Find the length of encoded Public Key
                if ((Reference[index + 1] & 0x80) == 0x80)
                {
                    int numBytes = Reference[index + 1] & 0x7F;
                    for (int m = 0; m < numBytes; m++)
                    {
                        length += (Reference[index + 2 + m] << ((numBytes - 1 - m) * 8));
                    }
                    length += 4;
                }
                else
                {
                    length = Reference[index + 1] + 2;
                }
            }
            return index;
        }
        static public byte[] EncodeOID(string szOID)
        {
            int[] OIDNums;
            byte[] pbEncodedTemp = new byte[64];
            byte[] pbEncoded = null;
            int n, index, num, count;
            OIDNums = ParseOID(szOID);
            pbEncodedTemp[0] = 6;
            pbEncodedTemp[2] = Convert.ToByte(OIDNums[0] * 40 + OIDNums[1]);
            count = 1;
            for (n = 2, index = 3; n < OIDNums.Length; n++)
            {
                num = OIDNums[n];
                if (num >= 16384)
                {
                    pbEncodedTemp[index++] = Convert.ToByte(num / 16384 | 0x80);
                    num = num % 16384;
                    count++;
                }
                if (num >= 128)
                {
                    pbEncodedTemp[index++] = Convert.ToByte(num / 128 | 0x80);
                    num = num % 128;
                    count++;
                }
                pbEncodedTemp[index++] = Convert.ToByte(num);
                count++;
            }
            pbEncodedTemp[1] = Convert.ToByte(count);
            pbEncoded = new byte[count + 2];
            Array.Copy(pbEncodedTemp, 0, pbEncoded, 0, count + 2);
            return pbEncoded;
        }
        static public int[] ParseOID(string szOID)
        {
            int nlast, n = 0;
            bool fFinished = false;
            int count = 0;
            int[] dwNums = null;
            do
            {
                nlast = n;
                n = szOID.IndexOf(".", nlast);
                if (n == -1) fFinished = true;
                count++;
                n++;
            } while (fFinished == false);
            dwNums = new int[count];
            count = 0;
            fFinished = false;
            do
            {
                nlast = n;
                n = szOID.IndexOf(".", nlast);
                if (n != -1)
                {
                    dwNums[count] = Convert.ToInt32(szOID.Substring(nlast, n - nlast), 10);
                }
                else
                {
                    fFinished = true;
                    dwNums[count] = Convert.ToInt32(szOID.Substring(nlast, szOID.Length - nlast), 10);
                }
                n++;
                count++;
            } while (fFinished == false);
            return dwNums;
        }
