    [HttpPost]
    public string MakeMmLinks( string devices )
    {
    	List<Device> devicesList = JsonConvert.DeserializeObject<List<Device>>( devices );
    	...
    }
