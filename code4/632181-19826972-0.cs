            /// <summary>
        /// Removes any comm ports that are not explicitly defined as allowed in ALLOWED_TYPES
        /// </summary>
        /// <param name="allPorts">reference to List that will be checked</param>
        /// <returns></returns>
        private static void nullModemCheck(ref List<string> allPorts)
        {
            // Open registry to get the COM Ports available with the system
            RegistryKey regKey = Registry.LocalMachine;
            regKey = regKey.OpenSubKey(REG_COM_STRING);
            Dictionary<string, string> tempDict = new Dictionary<string, string>();
            foreach (string p in allPorts)
                tempDict.Add(p, p);
            // This holds any matches we may find
            string match = "";
            foreach (string subKey in regKey.GetValueNames())
            {
                // Name must contain either VCP or Seial to be valid. Process any entries NOT matching
                // Compare to subKey (name of RegKey entry)
                if (!(subKey.Contains("Serial") || subKey.Contains("VCP")))
                {
                    // Okay, this might be an illegal port.
                    // Peek in the dictionary, do we have this key? Compare to regKey.GetValue(subKey)
                    if(tempDict.TryGetValue(regKey.GetValue(subKey).ToString(), out match))         
                    {
                        // Kill it!
                        allPorts.Remove(match);
                        // Reset our output string
                        match = "";
                    }
                }
                
            }
            regKey.Close();
        }
