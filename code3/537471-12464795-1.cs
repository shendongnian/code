    public sealed class MachineKeySection : ConfigurationSection
    {
        internal static byte[] EncryptOrDecryptData(bool fEncrypt, byte[] buf, byte[] modifier, int start, int length,
                                                    bool useValidationSymAlgo, bool useLegacyMode, IVType ivType)
        {
            EnsureConfig(); 
            if (useLegacyMode) 
                useLegacyMode = _UsingCustomEncryption; // only use legacy mode for custom algorithms 
            System.IO.MemoryStream ms = new System.IO.MemoryStream(); 
            ICryptoTransform oDesEnc = GetCryptoTransform(fEncrypt, useValidationSymAlgo, useLegacyMode);
            CryptoStream cs = new CryptoStream(ms, oDesEnc, CryptoStreamMode.Write);
            // DevDiv Bugs 137864: Add Random or Hashed IV to beginning of data to be encrypted. 
            // IVType.None is used by MembershipProvider which requires compatibility even in SP2 mode.
            bool createIV = ((ivType != IVType.None) && (CompatMode > MachineKeyCompatibilityMode.Framework20SP1)); 
 
            if (fEncrypt && createIV)
            { 
                byte[]  iv       = null;
                int     ivLength = (useValidationSymAlgo ? _IVLengthValidation : _IVLengthDecryption);
                switch (ivType)
                { 
                case IVType.Hash:
                    iv = GetIVHash(buf, ivLength); 
                    break; 
                case IVType.Random:
                    iv = new byte[ivLength]; 
                    RandomNumberGenerator.GetBytes(iv);
                    break;
                }
                Debug.Assert(iv != null, "Invalid value for IVType: " + ivType.ToString("G")); 
                cs.Write(iv, 0, iv.Length);
            } 
 
            cs.Write(buf, start, length);
            if (fEncrypt && modifier != null) 
            {
                cs.Write(modifier, 0, modifier.Length);
            }
 
            cs.FlushFinalBlock();
            byte[] paddedData = ms.ToArray(); 
            byte[] bData; 
            cs.Close();
            ReturnCryptoTransform(fEncrypt, oDesEnc, useValidationSymAlgo, useLegacyMode); 
            // DevDiv Bugs 137864: Strip Random or Hashed IV from beginning of unencrypted data
            if (!fEncrypt && createIV)
            { 
                // strip off the first bytes that were either random bits or a hash of the original data
                // either way it is always equal to the key length 
                int ivLength = (useValidationSymAlgo ? _IVLengthValidation : _IVLengthDecryption); 
                int bDataLength = paddedData.Length - ivLength;
 
                // valid if the data is long enough to have included the padding
                if (bDataLength >= 0)
                {
                    bData = new byte[bDataLength]; 
                    // copy from the padded data to non-padded buffer bData.
                    // dont bother with copy if the data is entirely the padding 
                    if (bDataLength > 0) 
                    {
                        Buffer.BlockCopy(paddedData, ivLength, bData, 0, bDataLength); 
                    }
                }
                else
                { 
                    // data is not padded because it is not long enough
                    bData = paddedData; 
                } 
            }
            else 
            {
                bData = paddedData;
            }
 
            if (!fEncrypt && modifier != null && modifier.Length > 0)
            { 
                for(int iter=0; iter<modifier.Length; iter++) 
                    if (bData[bData.Length - modifier.Length + iter] != modifier[iter])
                        throw new HttpException(SR.GetString(SR.Unable_to_validate_data)); 
                byte[] bData2 = new byte[bData.Length - modifier.Length];
                Buffer.BlockCopy(bData, 0, bData2, 0, bData2.Length);
                bData = bData2;
            } 
            return bData;
        } 
    }
