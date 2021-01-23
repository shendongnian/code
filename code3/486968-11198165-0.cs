    private void button1_Click(object sender, EventArgs e)
        {
            ListPCIDevices(false, listBox1);
        }
        public static void ListPCIDevices(bool ListOnlyNetworkDevices, ListBox LB)
        {
            string NetKey = @"SYSTEM\ControlSet001\Enum\PCI";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(NetKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        foreach (string skSubName in sk.GetSubKeyNames())
                        {
                            using (RegistryKey ssk = sk.OpenSubKey(skSubName))
                            {
                                object ItemName = ssk.GetValue("DeviceDesc");
                                object ItemCat = ssk.GetValue("Class");
                                if (ItemCat == null) { ItemCat = "Unknown"; }
                                if ((ItemName != null) && ((ItemCat.ToString() == "Net")||(!ListOnlyNetworkDevices)))
                                {
                                    LB.Items.Add(ItemName.ToString().Split(';')[1]);
                                }
                            }
                        }
                    }
                }
            }
        }
