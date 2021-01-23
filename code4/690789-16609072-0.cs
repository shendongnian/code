    If(!list.Any(l=>l.ID==adapter.Id))
    {
    	list.Add(new NetworkAdapter(getDevice(adapter.Id))
    	{
    		Name = adapter.Name,
    		ID = adapter.Id,
    		Description = adapter.Description,
    		IPAddress = uniCast.Address.ToString(),
    		NetworkInterfaceType = adapter.NetworkInterfaceType.ToString(),
    		Speed = adapter.Speed.ToString("#,##0"),
    		MacAddress = getMacAddress(adapter.GetPhysicalAddress().ToString()),
    		gatewayIpAddress = gatewayIPAddressesDisplay
    	});
    
    }
