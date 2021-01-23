        using System;
        using System.Text;
    
        public static class Base64Conversions
        {
            public static string EncodeBase64(this string text, Encoding encoding = Encoding.UTF8)
            {
                if (text == null) return null;
    
                var bytes = encoding.GetBytes(text);
                return Convert.ToBase64String(bytes);
            }
    
            public static string DecodeBase64(this string encodedText, Encoding encoding = Encoding.UTF8)
            {
                if (encodedText == null) return null;
    
                var bytes = Convert.FromBase64String(encodedText);
                return encoding.GetString(bytes);
            }
        }
