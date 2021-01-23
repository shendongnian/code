    private void DisableBtn_Click(object sender, RoutedEventArgs e)
    {
        if (startupinfo.SelectedItem != null)
        {
            string s = startupinfo.SelectedItem.ToString();
            if (startupinfoDict.ContainsKey(s))
            {
                File.Delete(startupinfoDict[s]);
                return;
            }
            string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key == null)
                {
                    // Key doesn't exist. Do whatever you want to handle
                    // this case
                }
                else
                {
                    key.DeleteValue(startupinfo.SelectedItem.ToString());
                }
            }
        }
    }
