    String drive = "c";
    ManagementObject disk = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
    disk.Get();
    Console.WriteLine(disk["VolumeName"]);
    foreach (var props in disk.Properties)
    {
        Console.WriteLine(props.Name + " " + props.Value);
    }
    Console.ReadLine();
