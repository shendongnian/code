    public async Task<bool> IsLampOn(){
    	string responseData = await GetDataFromUrl("http://10.10.1.100:3480/data_request?id=lu_variableget&serviceId=urn:upnp-org:serviceId:SwitchPower1&Variable=Status&DeviceNum=7");
    	return (responseData == "1")
    }
    public async Task<string> GetDataFromUrl(string url){
    	HttpClient http = new HttpClient();
    	HttpResponseMessage response = await(http.GetAsync(new Uri(url)));
    	response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
