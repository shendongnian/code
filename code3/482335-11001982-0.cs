        /// <summary>
        /// For best results ensure all hosts are pingable, and turned on.  
        /// </summary>
        /// <returns>An ordered list of DCs with the PDCE first</returns>
        static LinkedList<DomainController> GetNearbyDCs()
        {
            LinkedList<DomainController> preferredDCs = new LinkedList<DomainController>();
            List<string> TestedDCs = new List<string>();
            using (var mysite = ActiveDirectorySite.GetComputerSite())
            {
                using (var currentDomain = Domain.GetCurrentDomain())
                {
                    DirectoryContext dctx = new DirectoryContext(DirectoryContextType.Domain, currentDomain.Name);
                    var listOfDCs = DomainController.FindAll(dctx, mysite.Name);
                    foreach (DomainController item in listOfDCs)
                    {
                        if (IsConnected(item.IPAddress))
                        {
                            // Enumerating "Roles" will cause the object to bind to the server
                            foreach (ActiveDirectoryRole roleItem in item.Roles)
                            {
                                if (!TestedDCs.Contains(item.Name))
                                {
                                    TestedDCs.Add(item.Name);
                                    if (roleItem == ActiveDirectoryRole.PdcRole)
                                    {
                                        preferredDCs.AddFirst(item);
                                        break;
                                    }
                                    else
                                    {
                                        if (preferredDCs.Count > 0)
                                        {
                                            var tmp = preferredDCs.First;
                                            preferredDCs.AddBefore(tmp, item);
                                        }
                                        else
                                        {
                                            preferredDCs.AddFirst(item);
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            preferredDCs.AddLast(item);
                        }
                    }
                }
            }
            return preferredDCs;
        }
        static bool IsConnected(string hostToPing)
        {
            string pingurl = string.Format("{0}", hostToPing);
            string host = pingurl;
            bool result = false;
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }
            return result;
        }
