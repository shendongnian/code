    void Main()
    {
    	var addr = IPAddress.Parse("192.80.24.200");
    	var str = IPAddressToString(addr);
    	Console.WriteLine(str);
    }
    
    public string IPAddressToString(IPAddress address)
    {
    	var result = new StringBuilder(8);
    	foreach(var b in address.GetAddressBytes())
    	{
    		result.AppendFormat("{0:x2}", b);
    	}
    	return result.ToString();
    }
