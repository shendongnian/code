    enum EncryptionMethods
    {
        None=0,
        HMACSHA1,
        HMACSHA256,
        HMACSHA384,
        HMACSHA512,
        HMACMD5
    }
    class SecretKeySpec
    {
        readonly EncryptionMethods _method;
        readonly byte[] _secretKey;
        public SecretKeySpec(byte[] secretKey, EncryptionMethods encryptionMethod)
        {
            _secretKey = secretKey;
            _method = encryptionMethod;
        }
    
        public EncryptionMethods Method => _method;
        public byte[] SecretKey => _secretKey;
    }
    
    class Mac:IDisposable
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
            rawHmac = mac.ComputeHash(Cardinity.ENCODING.GetBytes(data));            
       
        }
    
        public string AsBase64()
        {
            return System.Convert.ToBase64String(rawHmac);
        }
    
        public void Dispose()
        {
            mac?.Dispose();
        }
     }
