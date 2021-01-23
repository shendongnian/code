    request.Method = "GET";
    string signature = "";
    string strtime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ssZ");
    string secret = "xxxx";
    string message = "sellerid:email:" + strtime; 
    var encoding = new System.Text.ASCIIEncoding(); 
    byte[] keyByte = encoding.GetBytes(secret);
    byte[] messageBytes = encoding.GetBytes(message);
    using (var hmacsha256 = new HMACSHA256(keyByte))
    {
    var hash = new HMACSHA256(keyByte);
    byte[] signature1 = hash.ComputeHash(messageBytes);
    signature = BitConverter.ToString(signature1).Replace("-", "").ToLower();
    }
    request.Headers.Add("authorization", "HMAC-SHA256" + " " + 
    "emailaddress=xxx@xx.com,timestamp=" + strtime + ",signature=" + signature);
    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            
   
