    private string Hash(string message, byte[] secretKey)
    {
       byte[] msgBytes = System.Text.Encoding.UTF8.GetBytes(message);
       byte[] hashBytes;
       using (HMACSHA1 hmac = new HMACSHA1(secretKey))
       { 
           hashBytes = hmac.ComputeHash(msgBytes); 
       }
       var sb = new StringBuilder();
       for (int i = 0; i < hashBytes.Length; i++) 
             sb.Append(hashBytes[i].ToString("x2"));
       string hexString = sb.ToString();
       byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(hexString);
       return UrlEncode(System.Convert.ToBase64String(toEncodeAsBytes));
    }
