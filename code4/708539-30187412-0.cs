      private static byte[] GetKey(string password)
      {
         string pwd = null;
         if (Encoding.UTF8.GetByteCount(password) < 24)
         {
             pwd = password.PadRight(24, ' ');
         }
         else
         {
             pwd = password.Substring(0, 24);
         }
         return Encoding.UTF8.GetBytes(pwd);
      }
