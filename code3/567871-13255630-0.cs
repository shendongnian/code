    // System Libraries
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    // Rally .NET REST Library
    using Rally.RestApi;
    using Rally.RestApi.Response;
    
    namespace RestExample_AddUsersToProject
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                String userName = "user@company.com";
                String userPassword = "topsecret";
                String serverUrl = "https://rally1.rallydev.com";
                String wsapiVersion = "1.38";
                
                RallyRestApi restApi = new RallyRestApi(
                    userName,
                    userPassword,
                    serverUrl,
                    wsapiVersion
                );
    
                restApi.Headers[RallyRestApi.HeaderType.Vendor] = "Rally Software";
                restApi.Headers[RallyRestApi.HeaderType.Name] = "RestExample_AddUsersToProject";
    
                // Query for Project for which we want to add permissions
                Request projectRequest = new Request("project");
                projectRequest.Fetch = new List<string>()
                {
                    "Name",
                    "Owner",
                    "State",
                    "Description"
                };
                String projectName = "Avalanche Hazard Mapping";
    
                projectRequest.Query = new Query("Name", Query.Operator.Equals, projectName);
                QueryResult queryProjectResults = restApi.Query(projectRequest);
                var myProject = queryProjectResults.Results.First();
                String myProjectReference = myProject["_ref"];
                
                Console.WriteLine("Project Name: " + myProject["Name"]);
                Console.WriteLine("State: " + myProject["State"]);
    
                // Query for User for whom we wish to add ProjectPermission
                Request userRequest = new Request("user");
                userRequest.Fetch = new List<string>()
                    {
                        "UserName",
                        "Subscription",
                        "DisplayName"
                    };
                
                
                // User needing the permissions
                userRequest.Query = new Query("UserName", Query.Operator.Equals, "\"boromir@midearth.com\"");
                QueryResult queryUserResults = restApi.Query(userRequest);
    
                var myUser = queryUserResults.Results.First();
                String myUserReference = myUser["_ref"];
    
                Console.WriteLine("Username: " + myUser["UserName"]);
                Console.WriteLine("Display Name: " + myUser["DisplayName"]);
                Console.WriteLine("Subscription: " + myUser["Subscription"]);
                
                // Setup required ProjectPermission data
                DynamicJsonObject newProjectPermission = new DynamicJsonObject();
    
                newProjectPermission["User"] = myUser;
                newProjectPermission["Project"] = myProject;
                newProjectPermission["Role"] = "Editor";
    
                // Create the permission in Rally
                CreateResult addProjectPermissionResult = restApi.Create("ProjectPermission", newProjectPermission);
    
                DynamicJsonObject fetchedProjectPermission = restApi.GetByReference(addProjectPermissionResult.Reference, "Name");
                Console.WriteLine("Created ProjectPermission with Role: " + fetchedProjectPermission["Name"]);            
            }
        }
    }
