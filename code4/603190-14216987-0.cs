    private bool ValidateHash(String uid, String hash, DataToSign data) {
            StringBuilder strToSign = new StringBuilder();
            strToSign.Append(data.HttpMethod + '\n');
            strToSign.Append(data.Date.ToString("r") + '\n');
            strToSign.Append(data.Uri);
           		
            Byte[] secretBytes = UTF8Encoding.UTF8.GetBytes(this._secretKey);
            HMACSHA1 hmac = new HMACSHA1(secretBytes);
			
            Byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(strToSign.ToString());
            Byte[] calcHash = hmac.ComputeHash(dataBytes);
            String calcHashString = Convert.ToBase64String(calcHash);
            if (calcHashString.Equals(hash)) {
                if (log.IsDebugEnabled) log.Debug(uid + " - [ValidateHash] HMAC is valid.");
                return true;
            }
            return false;
        }
