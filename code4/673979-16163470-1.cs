            string macAddress = string.Empty;
            if (!IsHostAccessible(ipAddress)) return null;
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                Process process = new Process();
                processStartInfo.FileName = "arp";
                processStartInfo.RedirectStandardInput = false;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.Arguments = "-a " + ipAddress;
                processStartInfo.UseShellExecute = false;
                process = Process.Start(processStartInfo);
                int Counter = -1;
                while (Counter <= -1)
                {                  
                        Counter = macAddress.Trim().ToLower().IndexOf("mac address", 0);
                        if (Counter > -1)
                        {
                            break;
                        }
                        macAddress = process.StandardOutput.ReadLine();
                        if (macAddress != "")
                        {
                            string[] mac = macAddress.Split(' ');
                            if (Array.IndexOf(mac, ipAddress) > -1)                                
                            {
                                if (mac[11] != "")
                                {
                                    macAddress = mac[11].ToString();
                                    break;
                                }
                            }
                        }
                }
                process.WaitForExit();
                macAddress = macAddress.Trim();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed because:" + e.ToString());
            }
            return macAddress;
        }
