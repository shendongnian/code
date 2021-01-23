    public static bool GetDriveVidPid(string szDriveName, ref ushort wVID, ref ushort wPID)
    {
       bool bResult = false;
       string szSerialNumberDevice = null;
    
       ManagementObject oLogicalDisk = new ManagementObject("Win32_LogicalDisk.DeviceID='" + szDriveName.TrimEnd('\\') + "'");
       foreach(ManagementObject oDiskPartition in oLogicalDisk.GetRelated("Win32_DiskPartition"))
       {
          foreach(ManagementObject oDiskDrive in oDiskPartition.GetRelated("Win32_DiskDrive"))
          {
             string szPNPDeviceID = oDiskDrive["PNPDeviceID"].ToString();
             if(!szPNPDeviceID.StartsWith("USBSTOR"))
                throw new Exception(szDriveName + " ist kein USB-Laufwerk.");
    
             string[] aszToken = szPNPDeviceID.Split(new char[] { '\\', '&' });
             szSerialNumberDevice = aszToken[aszToken.Length - 2];
          }
       }
    
       if(null != szSerialNumberDevice)
       {
          ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(@"root\CIMV2", "Select * from Win32_USBHub");
          foreach(ManagementObject oResult in oSearcher.Get())
          {
             object oValue = oResult["DeviceID"];
             if(oValue == null)
                continue;
    
             string szDeviceID = oValue.ToString();
             string[] aszToken = szDeviceID.Split(new char[] { '\\' });
             if(szSerialNumberDevice != aszToken[aszToken.Length - 1])
                continue;
    
             int nTemp = szDeviceID.IndexOf(@"VID_");
             if(0 > nTemp)
                continue;
    
             nTemp += 4;
             wVID = ushort.Parse(szDeviceID.Substring(nTemp, 4), System.Globalization.NumberStyles.AllowHexSpecifier);
    
             nTemp += 4;
             nTemp = szDeviceID.IndexOf(@"PID_", nTemp);
             if(0 > nTemp)
                continue;
    
             nTemp += 4;
             wPID = ushort.Parse(szDeviceID.Substring(nTemp, 4), System.Globalization.NumberStyles.AllowHexSpecifier);
    
             bResult = true;
             break;
          }
       }
    
       return bResult;
    }
