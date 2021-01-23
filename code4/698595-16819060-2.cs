    public static void spotcall()
        {
            string dial = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("INTERCOMCS").GetValue("DIAL").ToString();
                
    
            foreach (char c in dial)
            {
                sideapp.Keyboard.SendKey(c.ToString(), checkBoxPrivate.Checked);
            }            
        }
