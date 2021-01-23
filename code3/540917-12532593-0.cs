    private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Get all the disk drives
                ManagementObjectSearcher mosDisk = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                // Loop through each object (disk) retrieved by WMI
                foreach (ManagementObject moDisk in mosDisk.Get())
                {
                     cmbHdd.Items.Add(moDisk["Model"].ToString());
                }
            }
            catch(Exception exp)
            {
            }
        }
        private void cmbHdd_SelectedIndexChanged(object sender,EventArgs e)
        {
            try
            {
                ManagementObjectSearcher mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE Model = '" + cmbHdd.SelectedItem + "'");
                foreach (ManagementObject moDisk in mosDisks.Get())
                {
                     lblType.Text = "Type: " + moDisk["MediaType"].ToString();
                     lblModel.Text = "Model: " + moDisk["Model"].ToString();
                     lblCapacity.Text = "Capacity: " + moDisk["Size"].ToString();
                     lblPartitions.Text = "Partitions: " + moDisk["Partitions"].ToString();
                     lblSectors.Text = "Sectors: " + moDisk["SectorsPerTrack"].ToString();
                     lblSignature.Text = "Signatures: " +moDisk["Signature"].ToString();
                     lblFirmware.Text = "Firmware: " +moDisk["FirmwareRevision"].ToString();
                }
            }
            catch(Exception exp)
            {
            }
        }
