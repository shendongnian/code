    using (var client = new WebClient())
            {
                string json = client.DownloadString(url);
                string output = json.ToString();
    
                dynamic outputArray = JsonConvert.DeserializeObject(output);
                
                string _age = outputArray.age;
                string appID = outputArray.data.app_id;
                Debug.Write(outputArray.Something); //Just match value of json        
            }
