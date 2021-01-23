    public static class Reg_v_no_string 
    { 
        public static string reg_value(string key_place, string key) 
        { 
            string value = string.Empty; 
     
             RegistryKey klase = Registry.CurrentUser; 
             // todo: add some error checking to make sure the key is opened, etc.
             klase = klase.OpenSubKey(key_place); 
             value = klase.GetValue(key).ToString(); 
             klase.Close(); 
     
            return value; 
        } 
    } 
