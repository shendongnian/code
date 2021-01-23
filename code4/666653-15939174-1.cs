    private void DisableBtn_Click(object sender, RoutedEventArgs e)
    {
        if (startupinfo.SelectedItem != null)
        {
            string s = startupinfo.SelectedItem.ToString();
            if (startupinfoDict.ContainsKey(s))
            {
                File.Delete(startupinfoDict[s]);
            }
            string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null)
                {
                    key.DeleteValue(startupinfo.SelectedItem.ToString());
                }
            }
        }
    }
