    using System.management;
    
    
    //Code for retrieving motherboard's serial number
    ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
    foreach (ManagementObject getserial in MOS.Get())
    {
    textBox1.Text = getserial["SerialNumber"].ToString();
    }
    
    //Code for retrieving Processor's Identity
    MOS = new ManagementObjectSearcher("Select * From Win32_processor");
    foreach (ManagementObject getPID in MOS.Get())
    {
    textBox2.Text = getPID["ProcessorID"].ToString();
    }
    
    //Code for retrieving Network Adapter Configuration
    MOS = new ManagementObjectSearcher("Select * From Win32_NetworkAdapterConfiguration");
    foreach (ManagementObject mac in MOS.Get())
    {
    textBox3.Text = mac["MACAddress"].ToString();
    }
