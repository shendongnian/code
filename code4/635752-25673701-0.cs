    public static void InsertItem(Uri endpointUri, object data)
    {
         using (var client = new WebClient())
         {
             var dataString = JsonConvert.SerializeObject(data);
             client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
             client.UploadString(endpointUri, "POST", dataString);
             client.UploadStringCompleted += completed;
         }
    }
