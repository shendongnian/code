    private void textBox3_TextChanged(object sender, EventArgs e)
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        foreach (DriveInfo d in allDrives)
        {
            if (d.IsReady && d.DriveType == DriveType.Network)
            {
                textBox3.Text+= String.Format("{0} Drive {1} is ready and a network drive", Environment.NewLine, d.VolumeLabel);
            }
        }
    }
