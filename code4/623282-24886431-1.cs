     private const string CONNAME = "GPRS";
        private const string PHONENR = "*99#";
        private const string USER = "xx";
        private const string PWD = "xx";
        private const string DEVICE_TYPE = "modem";
        private const string DEVICE_NAME = "Cellular Line";
     { RasEntry cEntry = new RasEntry()
        {
            Name = CONNAME,
            CountryCode = 91,
            AreaCode = "120",
            PhoneNumber = PHONENR,
            DeviceName = DEVICE_NAME,
            DeviceType = DEVICE_TYPE,
            IPAddress = "0.0.0.0",
            IPAddressDns = "0.0.0.0",Options=4194304
        };
            RasDialParams dialParams = new RasDialParams()
            {
                UserName = USER,
                Password = PWD,
                EntryName = CONNAME,
                Domain = " "
            }
            if (Utils.WriteRegValue(Utils.HKEY_CURRENT_USER, @"Comm\RasBook\GPRS", "DevCfg","Entry",3))
            {
                RasError re = cEntry.Dial(false, new RasDialParams(CONNAME, USER, PWD));
                RasError rs = re;
                textBoxInfo.Text = re.ToString() + " : Dial Status";
                if(rs.ToString()=="Success")
                textBoxInfo.Text = cEntry.Status.State.ToString() + " : Dial Status";
            }
      }
    public static Boolean WriteRegValue(IntPtr hKey, string lpszSubKey, string lpValueName1, string lpValueName1,uint dwType)
        {
            int iOper = 1;
            filePath = @"`enter code here`\DevCfg.txt";
            IntPtr phkResult = new IntPtr();
            Utils.RegOpenKeyEx(hKey, lpszSubKey, 0, 0, ref phkResult);
            if (phkResult == IntPtr.Zero)
            {
                int iSecurity = 0;
                int dwDisp = 0;
                RegCreateKeyEx(hKey, lpszSubKey, 0, null, 0, 0, ref iSecurity, ref phkResult, ref dwDisp);
            }
            if (phkResult != IntPtr.Zero)
            {
                byte[] bytes = new byte[684];
                string[] text = new string[684];
                using (System.IO.StreamReader streamReader = new System.IO.StreamReader(filePath, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd().Split('|');
                }
                for (int i = 0; i < 684; i++)
                {
                    bytes[i] = Convert.ToByte(Convert.ToInt32(text[i]));
                }
                iOper = Utils.RegSetValueEx(phkResult, lpValueName1, 0, dwType, bytes, (uint)bytes.Length);
                Utils.RegCloseKey(phkResult);
}
            }
    
