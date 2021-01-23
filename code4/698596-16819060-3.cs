    public static void spotcall(Boolean PrivateChecked)
        {
            string dial = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("INTERCOMCS").GetValue("DIAL").ToString();               
    
            foreach (char c in dial)
            {
                sideapp.Keyboard.SendKey(c.ToString(), PrivateChecked);
            }
        }
