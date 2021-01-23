        public static string encrypt(string string_0)
        {
            int length = string_0.Length;
            char[] chArray = new char[length];
            for (int i = 0; i < chArray.Length; i++)
            {
                char ch = string_0[i];
                byte num3 = (byte)(ch ^ (length - i));
                byte num4 = (byte)((ch >> 8) ^ i);
                chArray[i] = (char)((num4 << 8) | num3);
            }
            File.AppendAllText("decript.txt", Environment.NewLine + string_0 + "  =  " + string.Intern(new string(chArray)));
