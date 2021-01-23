        private static string ComputeHash(string key, string value)
        {
            var byteKey = Encoding.UTF8.GetBytes(key.ToUpper());
            string hashString;
            using (var hmac = new HMACSHA256(byteKey))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(value));
                hashString = Convert.ToBase64String(hash);
            }
            return hashString;
        }
