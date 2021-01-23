    ManagementObjectSearcher manObjSearch = new ManagementObjectSearcher("Select * from Win32_SerialPort");
    ManagementObjectCollection manObjReturn = manObjSearch.Get();
    foreach (ManagementObject manObj in manObjReturn)
    {
        //int s = ManObj.Properties.Count;
        //foreach (PropertyData d in ManObj.Properties)
        //{
        //    MessageBox.Show(d.Name);
        //}
        MessageBox.Show(manObj["DeviceID"].ToString());
        MessageBox.Show(manObj["Name"].ToString());
        MessageBox.Show(manObj["Caption"].ToString());
    }
