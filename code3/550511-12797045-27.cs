        public byte[] CreateIV(string password)
        {
            var salt = new byte[] { 4, 7, 21, 199, 45, 63, 138, 12, 213, 1 };
            const int Iterations = 325;
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations))
                return rfc2898DeriveBytes.GetBytes(16);
        }
