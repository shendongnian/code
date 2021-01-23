        public static string ByteArrayToStringUtf8(byte[] value)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(value);
        }
