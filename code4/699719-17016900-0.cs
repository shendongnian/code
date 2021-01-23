        public static List<PointF> GetDesktopMonitors()
        {
            List<PointF> screenSizeList = new List<PointF>();
            //////////////////////////////////////////////////////////////////////////
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM WmiMonitorID");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Debug.WriteLine("-----------------------------------------------");
                    Debug.WriteLine("WmiMonitorID instance");
                    Debug.WriteLine("----------------");
               //   Console.WriteLine("Active: {0}", queryObj["Active"]);
                    Debug.WriteLine("InstanceName: {0}", queryObj["InstanceName"]);
               //   dynamic snid = queryObj["SerialNumberID"];
               //   Debug.WriteLine("SerialNumberID: (length) {0}", snid.Length);
                    Debug.WriteLine("YearOfManufacture: {0}", queryObj["YearOfManufacture"]);
                    /*
                    foreach (PropertyData data in queryObj.Properties)
                    {
                        Debug.WriteLine(data.Value.ToString());
                    }
                    */
                    
                    dynamic code = queryObj["ProductCodeID"];
                    string pcid = "";
                    for (int i = 0; i < code.Length; i++)
                    {
                        pcid = pcid + Char.ConvertFromUtf32(code[i]);
                      //pcid = pcid +code[i].ToString("X4");
                    }
                    Debug.WriteLine("ProductCodeID: " + pcid);
                    
                    int xSize = 0;
                    int ySize = 0;
                    string PNP = queryObj["InstanceName"].ToString();
                    PNP = PNP.Substring(0, PNP.Length - 2);  // remove _0
                    if (PNP != null && PNP.Length > 0) 
                    {
                        string displayKey = "SYSTEM\\CurrentControlSet\\Enum\\";
                        string strSubDevice = displayKey + PNP + "\\" + "Device Parameters\\";
                        // e.g.
                        // SYSTEM\CurrentControlSet\Enum\DISPLAY\LEN40A0\4&1144c54c&0&UID67568640\Device Parameters
                        // SYSTEM\CurrentControlSet\Enum\DISPLAY\LGD0335\4&1144c54c&0&12345678&00&02\Device Parameters
                        //
                        Debug.WriteLine("Register Path: " + strSubDevice);
                        RegistryKey regKey = Registry.LocalMachine.OpenSubKey(strSubDevice, false);
                        if (regKey != null)
                        {
                            if (regKey.GetValueKind("edid") == RegistryValueKind.Binary)
                            {
                                Debug.WriteLine("read edid");
                                byte[] edid = (byte[])regKey.GetValue("edid");
                                const int edid_x_size_in_mm = 21;
                                const int edid_y_size_in_mm = 22;
                                xSize = ((int)edid[edid_x_size_in_mm] * 10);
                                ySize = ((int)edid[edid_y_size_in_mm] * 10);
                                Debug.WriteLine("Screen size cx=" + xSize.ToString() + ", cy=" + ySize.ToString());
                            }
                            regKey.Close();
                        }
                    }
                    Debug.WriteLine("-----------------------------------------------");
                    PointF pt = new PointF();
                    pt.X = (float)xSize;
                    pt.Y = (float)ySize;
                    screenSizeList.Add(pt);
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }
            return screenSizeList;
        }
