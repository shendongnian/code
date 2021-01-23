    public static byte[] StrToByteArray(string sData)
            {
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                return encoding.GetBytes(sData);
            }
