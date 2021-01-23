    namespace RESTexample_storiesFromIteration
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                //Initialize the REST API
                RallyRestApi restApi;
                restApi = new RallyRestApi("user@domain.com", "1984", "https://rally1.rallydev.com", "1.43");
    
                //Set our Workspace and Project scopings
                String workspaceRef = "/workspace/1111";
                String projectRef = "/project/2222";
                bool projectScopingUp = false;
                bool projectScopingDown = true;
    
                DateTime now = DateTime.Today;
                String nowString = now.ToString("yyyy-MM-dd");
    
                Request iterationRequest = new Request("Iteration");
                iterationRequest.Workspace = workspaceRef;
                iterationRequest.Project = projectRef;
    
                iterationRequest.Fetch = new List<string>()
                    {
                        "Name",
                        "StartDate",
                        "EndDate",
                        "Project",
                        "State"
                    };
    
                String iterationQueryString = "((StartDate <= \"" + nowString + "\") AND (EndDate >= \"" + nowString + "\"))";
                iterationRequest.Query = new Query(iterationQueryString);
    
                QueryResult queryIterationResults = restApi.Query(iterationRequest);
    
                var myIteration = queryIterationResults.Results.First();
                var myIterationName = myIteration["Name"];
                var myIterationProject = myIteration["Project"];
                var myIterationProjectName = myIterationProject["Name"];
    
                Console.WriteLine("Name: " + myIterationName);
                Console.WriteLine("Project Ref: " + myIterationProjectName);
                Console.WriteLine("State: " + myIteration["State"]);
    
                // Query for Stories
    
                Request storyRequest = new Request("hierarchicalrequirement");
                storyRequest.Workspace = workspaceRef;
                storyRequest.Project = projectRef;
                storyRequest.ProjectScopeUp = projectScopingUp;
                storyRequest.ProjectScopeDown = projectScopingDown;
                storyRequest.Fetch = new List<string>()
                    {
                        "Name",
                        "ObjectID",
                        "ScheduleState",
                        "State",
                        "FormattedID",
                        "PlanEstimate",
                        "Iteration",
                        "Tasks"
                    };
    
                storyRequest.Query = new Query("Iteration.Name", Query.Operator.Equals, myIterationName);
                QueryResult queryStoryResults = restApi.Query(storyRequest);
    
                foreach (var s in queryStoryResults.Results)
                {
                    Console.WriteLine("----------");
                    Console.WriteLine("FormattedID: " + s["FormattedID"]);
                    Console.WriteLine("Name: " + s["Name"]);
                    Console.WriteLine("PlanEstimate: " + s["PlanEstimate"]);
    
                    var tasks = s["Tasks"];
                    
                    foreach (var t in tasks)
                     {
                         Console.WriteLine("Task: " + t["FormattedID"] + " " + t["State"]);
                     }
                }
    
            }
        }
    }
