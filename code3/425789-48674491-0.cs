    IHTMLDocument2 doc = new HTMLDocument() as IHTMLDocument2;
    DisableDebuggersAndNotification(true);
    doc.write(_res);
    DisableDebuggersAndNotification(false);
        private void DisableDebuggersAndNotification(bool setValue)
        {
            string val = null;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\Main", true))
            {
                if (key != null)
                {
                    val = (setValue) ? "yes" : "no";
                    key.SetValue("DisableScriptDebuggerIE", val, RegistryValueKind.String);
                    val = (setValue) ? "yes" : "no";
                    key.SetValue("Disable Script Debugger", val, RegistryValueKind.String);
                    val = (!setValue) ? "yes" : "no";
                    key.SetValue("Error Dlg Displayed On Every Error", val, RegistryValueKind.String);
                }
            }
        }
