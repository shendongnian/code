                List<YourObject> listObjects = new List<YourObject>();
            
             
                string response = "";
                using (var client = new WebClient() { UseDefaultCredentials = true })
                {
                     response = client.DownloadString(apiUrl);
                }
                listObjects = JsonConvert.DeserializeObject<List<YourObject>>(response);
                return listObjects ;
            
