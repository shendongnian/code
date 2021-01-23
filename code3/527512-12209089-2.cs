        const string DWORD_FOR_ACTIVE_SCRIPTING = "1400";
        const string VALUE_FOR_DISABLED = "3";
        const string VALUE_FOR_ENABLED = "0";
        public static bool IsJavascriptEnabled( )
        {
            bool retVal = true;
            //get the registry key for Zone 3(Internet Zone)
            Microsoft.Win32.RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3", true);
            if (key != null)
            {
                Object value = key.GetValue(DWORD_FOR_ACTIVE_SCRIPTING, VALUE_FOR_ENABLED);
                if( value.ToString().Equals(VALUE_FOR_DISABLED) )
                {
                    retVal = false;
                }
            }
            return retVal;
        }
