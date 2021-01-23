	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Rally.RestApi;
	using Rally.RestApi.Response;
	namespace RestExample_QueryStoryHierarchy
	{
		class Program
		{
			static void Main(string[] args)
			{
				// This will be the FormattedID of the top-level story from which we want to start traversing down
				string queryFormattedID = "US1";
				Console.WriteLine("Starting to walk Story Tree at: " + queryFormattedID);
				WalkTree.queryStoryTree(queryFormattedID);
				Console.WriteLine("Finished walking the tree...");
				Console.ReadKey();
			}
		}
		// Class with Static function to recursively walk a story tree
		static class WalkTree
		{
			public static void queryStoryTree(string inputFormattedID)
			{
				//Query for items
				Request request = new Request("hierarchicalrequirement");
				request.Fetch = new List<string>()
					{
						"Name",
						"Description",
						"FormattedID",
						"Children"
					};
				// Query Rally for Story
				request.Query = new Query("FormattedID", Query.Operator.Equals, inputFormattedID);
				RallyRestApi restApi = rallyRestApiRef.getRestApi;
				QueryResult queryResult = restApi.Query(request);
				
				// Grab story Children and process each Child
				foreach (var result in queryResult.Results)
				{
					Console.WriteLine(" Parent:");
					Console.WriteLine(result["Name"]);
					var resultChildren = result["Children"];
					foreach (var resultChild in resultChildren)
					{
						string childFormattedID = resultChild["FormattedID"];
						string childName = resultChild["Name"];
						Console.WriteLine("Child/Grandchild Name:");
						Console.WriteLine(childName);
						// Call self recursively on Children to continue walking the tree
						queryStoryTree(childFormattedID);
					}
				}
			}
		}
		// Static class providing reference to Rally to other member Classes
		static class rallyRestApiRef
		{
			private static String userName = "user@company.com";
			private static String userPassword = "topsecret";
			private static String serverUrl = "https://rally1.rallydev.com";
			private static String wsapiVersion = "1.43";
				
			private static RallyRestApi _restApi =
				new RallyRestApi(userName,
								 userPassword,
								 serverUrl,
								 wsapiVersion);
			public static RallyRestApi getRestApi
			{
				get { return _restApi; }
			}
		}
	}
