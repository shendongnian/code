      public static void RefreshARP()
            {
                _arpList = new Dictionary<string, string>();
                _arpList.Clear();
                try
                {
                    var arpStream = ExecuteCommandLine("arp", "-a");
                    // Consume first three lines
                    for (int i = 0; i < 3; i++)
                    {
                        arpStream.ReadLine();
                    }
                    // Read entries
                    while (!arpStream.EndOfStream)
                    {
                        var line = arpStream.ReadLine();
                        if (line != null)
                        {
                            line = line.Trim();
                            while (line.Contains("  "))
                            {
                                line = line.Replace("  ", " ");
                            }
                            var parts = line.Trim().Split(' ');
    
                            if (parts.Length == 3)
                            {
                                string ip = parts[0];
                                string mac = parts[1];
                                if (!_arpList.ContainsKey(ip))
                                    _arpList.Add(ip, mac);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogExceptionToFile(ex, "ARP Table");
                }
                if (_arpList.Count > 0)
                {
                    foreach (var nd in List)
                    {
                        string mac;
                        ARPList.TryGetValue(nd.IPAddress.ToString(), out mac);
                        nd.MAC = mac;    
                    }
                }
            }
