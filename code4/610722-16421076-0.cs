       Microsoft.Win32.RegistryKey m_RegEntry = Microsoft.Win32.Registry.LocalMachine;    
       m_RegEntry = m_RegEntry.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4D36E96D-E325-11CE-BFC1-08002BE10318}");
            //string 
            int i = 0;
            string[] m_szModemEntries = m_RegEntry.GetSubKeyNames();
