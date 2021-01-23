            List < List <string>> USBCOMlist = new List<List<string>>();
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_PnPEntity");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (queryObj["Caption"].ToString().Contains("(COM"))
                    {
                        List<string> DevInfo = new List<string>();
                        string Caption = queryObj["Caption"].ToString();
                        int CaptionIndex = Caption.IndexOf("(COM");
                        string CaptionInfo = Caption.Substring(CaptionIndex + 1).TrimEnd(')'); // make the trimming more correct                 
                        DevInfo.Add(CaptionInfo);
                        string deviceId = queryObj["deviceid"].ToString(); //"DeviceID"
                        int vidIndex = deviceId.IndexOf("VID_");
                        int pidIndex = deviceId.IndexOf("PID_");
                        string vid = "", pid = "";
                        if (vidIndex != -1 && pidIndex != -1)
                        {
                            string startingAtVid = deviceId.Substring(vidIndex + 4); // + 4 to remove "VID_"                    
                            vid = startingAtVid.Substring(0, 4); // vid is four characters long
                                                                 //Console.WriteLine("VID: " + vid);
                            string startingAtPid = deviceId.Substring(pidIndex + 4); // + 4 to remove "PID_"                    
                            pid = startingAtPid.Substring(0, 4); // pid is four characters long
                        }
                        DevInfo.Add(vid);
                        DevInfo.Add(pid);
                        USBCOMlist.Add(DevInfo);
                    }
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show(e.Message);
            }
