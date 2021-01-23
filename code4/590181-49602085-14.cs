    internal class Protected
    {
        private  Byte[] salt = Guid.NewGuid().ToByteArray();
    
        protected byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, salt, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException)//no reason for hackers to know it failed
            {
                return null;
            }
        }
    
        protected byte[] Unprotect(byte[] data)
        {
            try
            {
                return ProtectedData.Unprotect(data, salt, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException)//no reason for hackers to know it failed
            {
                return null;
            }
        }
    }
    
    
    internal class SecretKeySpec:Protected,IDisposable
    {
        readonly EncryptionMethods _method;
    
        private byte[] _secretKey;
        public SecretKeySpec(byte[] secretKey, EncryptionMethods encryptionMethod)
        {
            _secretKey = Protect(secretKey);
            _method = encryptionMethod;
        }
    
        public EncryptionMethods Method => _method;
        public byte[] SecretKey => Unprotect( _secretKey);
    
        public void Dispose()
        {
            if (_secretKey == null)
                return;
            //overwrite array memory
            for (int i = 0; i < _secretKey.Length; i++)
            {
                _secretKey[i] = 0;
            }
    
            //set-null
            _secretKey = null;
        }
        ~SecretKeySpec()
        {
            Dispose();
        }
    }
    
    internal class Mac : Protected,IDisposable
    {
        byte[] rawHmac;
        HMAC mac;
        public Mac(SecretKeySpec key, string data)
        {
    
            switch (key.Method)
            {
                case EncryptionMethods.HMACMD5:
                    mac = new HMACMD5(key.SecretKey);
                    break;
                case EncryptionMethods.HMACSHA512:
                    mac = new HMACSHA512(key.SecretKey);
                    break;
                case EncryptionMethods.HMACSHA384:
                    mac = new HMACSHA384(key.SecretKey);
                    break;
                case EncryptionMethods.HMACSHA256:
                    mac = new HMACSHA256(key.SecretKey);
                        
                break;
                case EncryptionMethods.HMACSHA1:
                    mac = new HMACSHA1(key.SecretKey);
                    break;
                    
                default:                    
                    throw new NotSupportedException("not supported HMAC");
            }
            rawHmac = Protect( mac.ComputeHash(Cardinity.ENCODING.GetBytes(data)));            
    
        }
    
        public string AsBase64()
        {
            return System.Convert.ToBase64String(Unprotect(rawHmac));
        }
    
        public void Dispose()
        {
            if (rawHmac != null)
            {
                //overwrite memory address
                for (int i = 0; i < rawHmac.Length; i++)
                {
                    rawHmac[i] = 0;
                }
    
                //release memory now
                rawHmac = null;
    
            }
            mac?.Dispose();
            mac = null;
    
        }
        ~Mac()
        {
            Dispose();
        }
    }
