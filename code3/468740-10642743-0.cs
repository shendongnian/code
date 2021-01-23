    public JsonResult AllStatuses() //from the json called in the _client view
        {
            var buildStatuses = new List<BuildStatus>();
            var projects = Client.AllProjects();           
            foreach (var project in projects)
            {                
                try 
                {
                    var buildConfigs = Client.BuildConfigsByProjectId(project.Id);
                    foreach (var buildConfig in buildConfigs)
                    {
                        var b = new BuildStatus();
                        var build = Client.LastBuildByBuildConfigId(buildConfig.Id);
                        var status = build.Status; // Used to loop through BuildConfigID's to find which is a FAILURE, SUCCESS, ERROR, or UNKNOWN
                        var change = Client.LastChangeDetailByBuildConfigId(buildConfig.Id); // Provides the changeID
                        var changeDetail = Client.ChangeDetailsByChangeId(change.Id); // Provides the username, this one populates the usernames
                        if (changeDetail != null)
                            b.user = changeDetail.Username;
                        b.id = buildConfig.Id.ToString();
                        
                        // If the date isn't null place the start date in long format
                        if (build.StartDate != null)
                            b.date = build.StartDate.ToString();
                        // If block; set the status based on the BuildconfigID from the var status
                        if (status.Contains("FAILURE")){
                            b.status = "FAILURE";
                        }
                        else if (status.Contains("SUCCESS")){
                            b.status = "SUCCESS";
                        }
                        else if (status.Contains("ERROR")){
                            b.status = "ERROR";
                        }
                        else{
                            b.status = "UNKNOWN";
                        }
                        buildStatuses.Add(b);
                    }
                   
                } catch { }
              
            }
            var query = buildStatuses.OrderBy(x => x.status); // Create a sorted list from Error - Unknown               
            return Json(query, JsonRequestBehavior.AllowGet);
