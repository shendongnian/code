    private String GetFreeSpace(String inp)
            {
                String totalspace = "", freespace = "", freepercent = "";
                Double sFree = 0, sTotal = 0, sEq = 0;
                ManagementObjectSearcher getspace = new ManagementObjectSearcher("Select * from Win32_LogicalDisk Where DeviceID='" + inp +"'");
                foreach (ManagementObject drive in getspace.Get())
                {
                    if (drive["DeviceID"].ToString() == inp)
                    {
                        freespace = drive["FreeSpace"].ToString();
                        totalspace = drive["Size"].ToString();
                        sFree = Convert.ToDouble(freespace);
                        sTotal = Convert.ToDouble(totalspace);
                        sEq = sFree * 100 / sTotal;
                        freepercent = (Math.Round((sTotal - sFree) / 1073741824, 2)).ToString() + " (" + Math.Round(sEq,0).ToString() + " %)";
                        return freepercent;
                    }
                }
                return "";
            }
            private String GetPartName(String inp)
            {
                //MessageBox.Show(inp);
                String Dependent = "", ret = "";
                ManagementObjectSearcher LogicalDisk = new ManagementObjectSearcher("Select * from Win32_LogicalDiskToPartition");
                foreach (ManagementObject drive in LogicalDisk.Get())
                {
                    if (drive["Antecedent"].ToString().Contains(inp))
                    {
                        Dependent = drive["Dependent"].ToString();
                        ret = Dependent.Substring(Dependent.Length - 3, 2);
                        break;
                    }
                    
                }
                return ret;
                
            }
