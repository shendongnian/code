     namespace RestExample_QueryRecycleBin	{
		class Program
		{
			static void Main(string[] args)
			{
				//Initialize the REST API
				RallyRestApi restApi;
				String userName = "user@company.com";
				String userPassword = "topsecret";
				// Set Rally parameters
				String rallyURL = "https://rally1.rallydev.com";
				String rallyWSAPIVersion = "1.40";
				//Initialize the REST API
				restApi = new RallyRestApi(userName,
										   userPassword,
										   rallyURL,
										   rallyWSAPIVersion);
				// Specify workspace and project
				string myWorkspace = "/workspace/12345678910";
				string myProject = "/project/12345678911";
				//Query for items
				Request request = new Request("recyclebinentry");
				request.Workspace = myWorkspace;
				request.Project = myProject;
				QueryResult queryResult = restApi.Query(request);
				foreach (var result in queryResult.Results)
				{
					//Process item
					string itemName = result["_refObjectName"];
					string itemRef = result["_ref"];
					Console.WriteLine(itemRef + ", " + itemName);
				}
				Console.ReadKey();
			}
		}
	}
