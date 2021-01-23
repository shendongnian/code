    private void setAsDefaultScreenSaver(string valuePath)
    {
           RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop",true);
        
           if (key == null)
             return;
           else
           {
              key.SetValue("SCRNSAVE.EXE", valuePath); 
              key.SetValue("ScreenSaveActive", "1");
           }
           key.Close(); //close the key and flush it to disk
        
        
     }
