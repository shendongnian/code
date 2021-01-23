        private static bool Validate(string sharedSecretKey)
        {
            var data = GetStreamAsText(HttpContext.Current.Request.InputStream, HttpContext.Current.Request.ContentEncoding);
            var keyBytes = Encoding.UTF8.GetBytes(sharedSecretKey);
            var dataBytes = Encoding.UTF8.GetBytes(data);
            //use the SHA256Managed Class to compute the hash
            var hmac = new HMACSHA256(keyBytes);
            var hmacBytes = hmac.ComputeHash(dataBytes);
            //retun as base64 string. Compared with the signature passed in the header of the post request from Shopify. If they match, the call is verified.
            var hmacHeader = HttpContext.Current.Request.Headers["x-shopify-hmac-sha256"];
            var createSignature = Convert.ToBase64String(hmacBytes);
            return hmacHeader == createSignature;
        }
        private static string GetStreamAsText(Stream stream, Encoding encoding)
        {
            var bytesToGet = stream.Length;
            var input = new byte[bytesToGet];
            stream.Read(input, 0, (int)bytesToGet);
            stream.Seek(0, SeekOrigin.Begin); // reset stream so that normal ASP.NET processing can read data
            var text = encoding.GetString(input);
            return text;
        }
