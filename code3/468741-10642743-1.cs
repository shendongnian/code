     public JsonResult AllStatuses() //from the json called in the _client view
        {
            List<Client> clients = storeDB.Clients.Include("Projects").Include("Projects.Builds").ToList();
            var buildStatuses = new List<BuildStatus>();
             
            foreach (var client in clients) {
                // Network credentials
                // Used to get the Json Service request                         // URL here: client.ClientURL
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:81/Status/AllStatuses");
                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var responseString = reader.ReadToEnd();
                var serializer = new JavaScriptSerializer();
                serializer.RegisterConverters((new[] { new DynamicJsonConverter() }));
                dynamic obj = serializer.Deserialize(responseString, typeof(object)) as dynamic;
                foreach (var objects in obj) // Pull apart the dynamic object
                {
                    var id = objects.id;
                    var status = objects.status;
                    var date = objects.date;
                    var user = objects.user;
                    var bs = new BuildStatus();
                    try
                    {
                        bs.status = status;
                        bs.date = date;
                        bs.id = id;
                        bs.user = user;
                    }
                    catch { throw; }
                    buildStatuses.Add(bs);
                }
            }              
            return Json(buildStatuses, JsonRequestBehavior.AllowGet);
        }
