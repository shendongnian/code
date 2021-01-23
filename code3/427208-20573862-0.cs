        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            //for each j you can get the MAC 
            PhysicalAddress address = nics[0].GetPhysicalAddress();
            byte[] bytes = address.GetAddressBytes();
            string macAddress = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                // Format the physical address in hexadecimal. 
                macAddress += bytes[i].ToString("X2");
                // Insert a hyphen after each byte, unless we are at the end of the address. 
                if (i != bytes.Length - 1)
                {
                    macAddress += "-";
                }
            }
            return macAddress;
        }
