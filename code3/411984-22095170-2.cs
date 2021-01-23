    ListViewGroup hddgrp;
                    lstHDD.Columns.Add("Disk");
                    lstHDD.Columns.Add("Patition");
                    lstHDD.Columns.Add("Free Space");
                    lstHDD.Columns.Add("Total Space");
                    
                    lstHDD.View = View.Details;
                    String DiskName = "";
                    String PartState = "";
                    String PartName = "";
                    String PartFree = "";
                    ManagementObjectSearcher hdd = new ManagementObjectSearcher("Select * from Win32_DiskDrive");
                    foreach (ManagementObject objhdd in hdd.Get())
                    {
                        PartState = "";
                        DiskName = "Disk " + objhdd["Index"].ToString() + " : " + objhdd["Caption"].ToString().Replace(" ATA Device", "") +
                            " (" + Math.Round( Convert.ToDouble(objhdd["Size"]) / 1073741824,1) + " GB)";
                        hddgrp = lstHDD.Groups.Add(DiskName, DiskName);
                        ObjCount = Convert.ToInt16(objhdd["Partitions"]);
                        ManagementObjectSearcher partitions = new ManagementObjectSearcher(
                            "Select * From Win32_DiskPartition Where DiskIndex='" + objhdd["Index"].ToString() + "'");
                        foreach(ManagementObject part in partitions.Get())
                        {
                            PartName = part["DeviceID"].ToString();
                            if (part["Bootable"].ToString() == "True" && part["BootPartition"].ToString() == "True")
                                PartState = "Recovery";
                            else
                            {
                                ManagementObjectSearcher getdisks = new ManagementObjectSearcher
                                    ("Select * From Win32_LogicalDiskToPartition Where  ");
                                PartState = GetPartName(PartName);
                                PartFree = GetFreeSpace(PartState);
                                PartState = "Local Disk (" + PartState + ")";
                            }
                            
                            lstHDD.Items.Add(new ListViewItem(new String[] { "Partition " + part["Index"].ToString(),
                                PartState,PartFree ,Math.Round( Convert.ToDouble(part["Size"].ToString()) / 1073741824,1) + " GB"}, hddgrp));
                        }
                    }
                    lstHDD.Columns[0].Width = 80;
                    lstHDD.Columns[1].Width = 120;
                    lstHDD.Columns[2].Width = 100;
                    lstHDD.Columns[3].Width = 100;
