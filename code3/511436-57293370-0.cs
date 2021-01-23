    public static string EncryptBase64(string StringToEncrypt)
            {
                byte[] buffer = (new UnicodeEncoding()).GetBytes(StringToEncrypt);
                return System.Convert.ToBase64String(buffer);
            }
