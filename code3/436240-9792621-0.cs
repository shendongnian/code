        public static string md5(string value)
        {
            byte[] encoded = ASCIIEncoding.UTF8.GetBytes(value);
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            byte[] hashCode = md5Provider.ComputeHash(encoded);
            
            string ret = "";
            foreach (byte a in hashCode)
                ret += String.Format("{0:x2}", a);
            return ret;
        }
