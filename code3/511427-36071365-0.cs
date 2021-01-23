    namespace MyApplication.Helpers.Encoding
    {
        public static class EncodingForBase64
        {
            public static string EncodeBase64(this System.Text.Encoding encoding, string text)
            {
                if (text == null)
                {
                    return null;
                }
    
                byte[] textAsBytes = encoding.GetBytes(text);
                return System.Convert.ToBase64String(textAsBytes);
            }
    
            public static string DecodeBase64(this System.Text.Encoding encoding, string encodedText)
            {
                if (encodedText == null)
                {
                    return null;
                }
    
                byte[] textAsBytes = System.Convert.FromBase64String(encodedText);
                return encoding.GetString(textAsBytes);
            }
        }
    }
