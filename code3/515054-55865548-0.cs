    public string GetAvailablePort()
            {int startingPort=1000;
                string portnumberinformation = string.Empty;
                IPEndPoint[] endPoints;
                List<int> portArray = new List<int>();
                IPGlobalPr`enter code here`operties properties = IPGlobalProperties.GetIPGlobalProperties();`enter code here`
                
                //getting active tcp listners 
                endPoints = properties.GetActiveTcpListeners();
                portArray.AddRange(from n in endPoints
                                   where n.Port >= startingPort
                                   select n.Port);    
             
                portArray.Sort();
    
                for (int i = 0; i < portArray.Count; i++)
                {
                    if (check condition)
                    {
                        do somting
                    }
                }
    
                return portnumberinformation;
            }
