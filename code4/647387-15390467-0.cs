    public class PasswordGenerator
    {
        private static Random random = new Random();
     
        public string Generate()
        {
            for (int i = 0; i < length; i++)
            {
                int x = random.Next(0, length);
    
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else
                    i--;
            }
            if (length < password.Length) password = password.Substring(0, length);
    
            return password;
        }
    }
