    private void uxSave_Click(object sender, EventArgs e)       
    {
    string username = Environment.UserName;
                if (MessageBox.Show("Are you sure to change startup of Item(s)?", "Confirm Startup", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                   
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (j%2 == 0)
                            list1.Add(list[j]);
    
                    }
    
                   foreach (DataGridViewRow ro in uxDgvStartupItems.Rows)
                    {
                        var cellname = (DataGridViewTextBoxCell) ro.Cells[1];
                        string x = Convert.ToString(cellname.Value);
                        foreach (string i in list1)
                        {
                           if (i == x)
                            {
                                string name = i;
                                var sourcee = (DataGridViewTextBoxCell)ro.Cells[2];
                                string source = Convert.ToString(sourcee.Value);
                                var CbxCell = (DataGridViewCheckBoxCell)ro.Cells[0];
    
                                if ((bool)CbxCell.Value == true)
                                {
                                    int flag = 0;
                                    string itemname = "";
                                    RegistryKey HKLM2 =
                                        Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Shared Tools\\MSConfig\\startupreg",
                                                                         true);
                                    foreach (string Programs in HKLM2.GetSubKeyNames())
                                    {
    
                                        RegistryKey productKey = HKLM2.OpenSubKey(Programs);
                                        if (productKey != null)
                                        {
                                            foreach (string value in productKey.GetValueNames())
                                            {
                                                if (value == "item")
                                                {
                                                    string txt = Convert.ToString(productKey.GetValue("item"));
    
                                                    if (txt == name)
                                                    {
                                                        itemname = Convert.ToString(productKey.GetValue("command"));
                                                        HKLM2.DeleteSubKey(name, false);
                                                        flag = 1;
    
                                                    }
    
                                                }
                                            }
                                        }
                                    }
    
    
                                    RegistryKey HKLM4 =
                                        Registry.LocalMachine.OpenSubKey(
                                            "SOFTWARE\\Microsoft\\Shared Tools\\MSConfig\\startupfolder", true);
                                    foreach (string Programs in HKLM4.GetSubKeyNames())
                                    {
    
                                        RegistryKey productKey = HKLM4.OpenSubKey(Programs);
                                        if (productKey != null)
                                        {
                                            foreach (string value in productKey.GetValueNames())
                                            {
                                                if (value == "item")
                                                {
                                                    string txt = Convert.ToString(productKey.GetValue("item"));
    
                                                    if (txt == name)
                                                    {
                                                        HKLM4.DeleteSubKey(Programs, false);
                                                        flag = 2;
                                                    }
    
                                                }
                                            }
                                        }
                                    }
    
    
                                    if (flag == 1)
                                    {
                                        RegistryKey startupKey =
                                            Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                                        startupKey.SetValue(name, itemname);
                                        startupKey.Close();
                                    }
    
                                    if (flag == 2)
                                    {
                                        string path = "C:\\Users\\" + username + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup";
                                        DirectoryInfo di = new DirectoryInfo(targetPath);
                                        FileInfo[] rgFiles = di.GetFiles("*.*");
                                        foreach (FileInfo fi in rgFiles)
                                        {
                                            string itemName = fi.Name;
                                            itemName = itemName.Substring(0, itemName.LastIndexOf('.'));
    
                                            if (itemName == name)
                                            {
    
                                                string sourceFile = Path.Combine(targetPath, name + ".lnk");
                                                string destFile = Path.Combine(path, name + ".lnk");
    
                                                File.Copy(sourceFile, destFile, true);
                                                fi.Delete();
    
                                                fi.Delete();
                                              
                                            }
    
                                        }
    
                                    }
    
                                }
                                else
                                {
    
                                    if (source == "registry")
                                    {
                                        int flag = 0;
                                        string path = "";
                                        RegistryKey startupKey =
                                            Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",
                                                                             true);
                                        foreach (string Programs in startupKey.GetValueNames())
                                        {
                                            if (Programs == name)
                                            {
                                                path = Convert.ToString(startupKey.GetValue(name));
                                                startupKey.DeleteValue(name, false);
                                                startupKey.Close();
                                                flag = 1;
                                            }
    
                                        }
    
                                        if (flag == 0)
                                        {
                                            RegistryKey startupKey1 =
                                                Registry.CurrentUser.OpenSubKey(
                                                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                                            foreach (string Programs in startupKey1.GetValueNames())
                                            {
                                                if (Programs == name)
                                                {
                                                    path = Convert.ToString(startupKey1.GetValue(name));
                                                    startupKey1.DeleteValue(name, false);
                                                    startupKey1.Close();
                                                }
    
                                            }
                                        }
    
                                        RegistryKey HKCU =
                                            Registry.LocalMachine.OpenSubKey(
                                                "SOFTWARE\\Microsoft\\Shared Tools\\MSConfig\\startupreg", true);
                                        RegistryKey HKCU1 = HKCU.CreateSubKey(name);
                                        HKCU1.SetValue("command", path);
                                        HKCU1.SetValue("hkey", "HKLM");
                                        HKCU1.SetValue("inimapping", "0");
                                        HKCU1.SetValue("item", name);
                                        HKCU1.SetValue("key", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                                        HKCU1.SetValue("DAY", DateTime.Now.Day);
                                        HKCU1.SetValue("MONTH", DateTime.Now.Month);
                                        HKCU1.SetValue("YEAR", DateTime.Now.Year);
                                        HKCU1.SetValue("HOUR", DateTime.Now.Hour);
                                        HKCU1.SetValue("MINUTE", DateTime.Now.Minute);
                                        HKCU1.SetValue("SECOND", DateTime.Now.Second);
                                    }
    
                                    if (source == "folder")
                                    {
                                        string path = "C:^Users^" + username + "^AppData^Roaming^Microsoft^Windows^Start Menu^Programs^Startup";
                                        string path1 = "C:\\Users\\" + username + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup";
                                        
                                        DirectoryInfo di =
                                            new DirectoryInfo("C:\\Users\\" + username + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");
                                        FileInfo[] rgFiles = di.GetFiles("*.*");
                                        foreach (FileInfo fi in rgFiles)
                                        {
                                            string itemName = fi.Name;
                                          itemName = itemName.Substring(0, itemName.LastIndexOf('.'));
    
                                            if (itemName == name)
                                            {
                                                string sourceFile = Path.Combine(path1, name + ".lnk");
                                                string destFile = Path.Combine(targetPath, name + ".lnk");
    
                                                File.Copy(sourceFile, destFile, true);
                                                fi.Delete();
                                             
                                            }
    
                                        }
    
                                        RegistryKey HKCU =
                                            Registry.LocalMachine.OpenSubKey(
                                                "SOFTWARE\\Microsoft\\Shared Tools\\MSConfig\\startupfolder", true);
                                        RegistryKey HKCU1 = HKCU.CreateSubKey(path + "^" + name);
                                        HKCU1.SetValue("path", path1 + "\\" + name);
                                        HKCU1.SetValue("location", path1);
                                        HKCU1.SetValue("item", name);
                                        HKCU1.SetValue("command", path1);
                                        HKCU1.SetValue("backupExtension", ".Startup");
                                        HKCU1.SetValue("backup", "C:\\Windows\\pss\\" + name + ".Startup");
                                        HKCU1.SetValue("DAY", DateTime.Now.Day);
                                        HKCU1.SetValue("MONTH", DateTime.Now.Month);
                                        HKCU1.SetValue("YEAR", DateTime.Now.Year);
                                        HKCU1.SetValue("HOUR", DateTime.Now.Hour);
                                        HKCU1.SetValue("MINUTE", DateTime.Now.Minute);
                                        HKCU1.SetValue("SECOND", DateTime.Now.Second);
    
                                    }
    
                                }
    
                              }
    
                        }
                    }
    
    
                    if (
                        MessageBox.Show("Do you want to restart system to save these changes", "Confirm Restart",
                                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool privilege;
                        WindowsIdentity identity = WindowsIdentity.GetCurrent();
                        WindowsPrincipal principal = new WindowsPrincipal(identity);
                        privilege = principal.IsInRole(WindowsBuiltInRole.Administrator);
                        if (privilege == true)
                        {
                            Process.Start("ShutDown", "/r");
                        }
                        else
                        {
                            MessageBox.Show("You have not sufficient privileges to restart computer");
                        }
                    }
    
                     list.Clear();
                    list1.Clear();
                }
            }
    
            private void uxDgvStartupItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
                
                //string[] list = new string[100];
                string name = Convert.ToString(uxDgvStartupItems.Rows[uxDgvStartupItems.CurrentCell.RowIndex].Cells[1].FormattedValue);
                list.Add(name);
                 
            }
