              using Microsoft.Win32;
              RegistryKey myregistry = Registry.CurrentUser.OpenSubKey("MyKey");
              if (myregistry != null)
              {
               string Value=myregistry.GetValue("ID").ToString();
              }
             
