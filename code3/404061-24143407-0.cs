    private string getLocalIP()
    {
        string Localip = "?";
        foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
        {
            
            var defaultGateway =  from nics in NetworkInterface.GetAllNetworkInterfaces()
   
    from props in nics.GetIPProperties().GatewayAddresses
       where nics.OperationalStatus == OperationalStatus.Up
       select props.Address.ToString(); // this sets the default gateway in a variable
            
            GatewayIPAddressInformationCollection prop = netInterface.GetIPProperties().GatewayAddresses;
            if(defaultGateway.First() != null){
            IPInterfaceProperties ipProps = netInterface.GetIPProperties();
 
            foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
            {
                
                if (addr.Address.ToString().Contains(defaultGateway.First().Remove(defaultGateway.First().LastIndexOf(".")))) // The IP address of the computer is always a bit equal to the default gateway except for the last group of numbers. This splits it and checks if the ip without the last group matches the default gateway
                {
                   
                    if (Localip == "?") // check if the string has been changed before
                    {
                        Localip = addr.Address.ToString(); // put the ip address in a string that you can use.
                    }
                }
                
            }
            }
            
        }
       return Localip;
    }
