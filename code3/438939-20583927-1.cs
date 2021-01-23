     private void comboBoxLanInternet_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                {
                    if (nic.Description == comboBoxLanInternet.SelectedItem.ToString())
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            MessageBox.Show(ip.Address.ToString());
                        }
                    }
                }
            }
        }
