    public static bool ReadRegString(IntPtr hKey, string lpszSubKey, string lpValueName)
        {
            try
            {
                string str = "";
                byte[] lpData = new byte[684];
                uint lpcbValue = 684;
                uint dwType = Utils.REG_BINARY;
                IntPtr phkResult = new IntPtr();
                Utils.RegOpenKeyEx(hKey, lpszSubKey, 0, 0, ref phkResult);
                if (phkResult != IntPtr.Zero)
                {
                    int x = Utils.RegQueryValueEx(phkResult, lpValueName, 0, ref dwType, lpData, ref lpcbValue);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < 684; i++)
                    {
                        if (i != 683)
                            sb.Append(lpData[i].ToString() + "|");
                        else
                            sb.Append(lpData[i].ToString());
                    }
                    using (System.IO.StreamWriter outfile = new System.IO.StreamWriter(filePath))
                    {
                        outfile.Write(sb.ToString());
                    }
                    Utils.RegCloseKey(phkResult);
            }
         }
    if (Utils.ReadRegString(Utils.HKEY_CURRENT_USER, @"Comm\RasBook\GPRS", "DevCfg"))
            {
                textBoxSysVers.Text = "Succeeded Make Text File.";
            }
