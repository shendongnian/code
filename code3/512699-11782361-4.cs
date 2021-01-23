        private static string ComputeHash(string encryptedPassword, string message)
        {
            var key = Encoding.UTF8.GetBytes(encryptedPassword.ToUpper());
            string hashString;
            using (var hmac = new HMACSHA256(key))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                hashString = Convert.ToBase64String(hash);
            }
            return hashString;
        }
