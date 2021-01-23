    public static void spotcall(Boolean PrivateChecked)
        {
            string dial = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("INTERCOMCS").GetValue("DIAL").ToString();
            MainForm.txtSendKeys.Text = dial;// Here it asks me for a reference to an object.
    
    
            foreach (char c in txtSendKeys.Text)
            {
                sideapp.Keyboard.SendKey(c.ToString(), PrivateChecked);
            }
            txtSendKeys.Clear();
        }
