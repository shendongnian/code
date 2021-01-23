    ManagementObjectSearcher manObjSearch = new ManagementObjectSearcher("Select * from Win32_SerialPort");
    ManagementObjectCollection manObjReturn = manObjSearch.Get();
    foreach (ManagementObject manObj in manObjReturn)
    {
        //int s = manObj.Properties.Count;
        //foreach (PropertyData d in manObj.Properties)
        //{
        //    Console.WriteLine(d.Name);
        //}
        Console.WriteLine(manObj["DeviceID"].ToString());
        Console.WriteLine(manObj["Name"].ToString());
        Console.WriteLine(manObj["Caption"].ToString());
    }
