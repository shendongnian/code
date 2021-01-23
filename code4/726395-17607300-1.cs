    string url = "http://api.amazon.com/messaging/registrations/1234/messages";
    var client = new HttpClient();
    
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                                                  "Bearer", "token");
    client.DefaultRequestHeaders.Accept.Add(
                  new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Add("X-Amzn-Type-Version",
                                       "com.amazon.device.messaging.ADMMessage@1.0");
    client.DefaultRequestHeaders.Add("X-Amzn-Accept-Type",
                                    "com.amazon.device.messaging.ADMSendResult@1.0");
    
    var kvp = new Dictionary<string, string>();
    kvp.Add("key1", "value1");
    kvp.Add("key2", "value2");
    
    var payload = new Payload()
    {
        consolidationKey = "Some Key", expiresAfter = 86400, data = kvp
    };
    
    var result = client.PostAsJsonAsync<Payload>(url, payload).Result;
