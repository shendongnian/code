     private void LanSetting_Load(object sender, EventArgs e)
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet) || (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)) //&& (nic.OperationalStatus == OperationalStatus.Up))
                {
                    comboBoxLanInternet.Items.Add(nic.Description);
                }
            }
        }
