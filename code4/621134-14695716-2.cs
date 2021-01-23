    // System Libraries
	using System;
	using System.Collections.Generic;
	using System.Collections;
	using System.Linq;
	using System.Text;
	using System.Web;
	// Rally REST API Libraries
	using Rally.RestApi;
	using Rally.RestApi.Response;
	namespace RestExample_AddChangesetToUserStory
	{
		class Program
		{
			static void Main(string[] args)
			{
				// Set user parameters
				String userName = "user@company.com";
				String userPassword = "topsecret";
				// Set Rally parameters
				String rallyURL = "https://rally1.rallydev.com";
				String rallyWSAPIVersion = "1.40";
				//Initialize the REST API
				RallyRestApi restApi;
				restApi = new RallyRestApi(userName,
										   userPassword,
										   rallyURL,
										   rallyWSAPIVersion);
				// Changeset Owner Username
				String changesetOwner = "scm_integration@company.com";
				// SCM Repository Name
				String scmRepositoryName = "MySCMRepo";
				// FormattedID of Artifact to associate to
				String storyFormattedID = "US14";
				
				// Create Request for User
				Request userRequest = new Request("user");
				userRequest.Fetch = new List<string>()
					{
						"UserName",
						"Subscription",
						"DisplayName"                    
					};
				// Add a Query to the Request
				userRequest.Query = new Query("UserName", Query.Operator.Equals, changesetOwner);
				// Query Rally
				QueryResult queryUserResults = restApi.Query(userRequest);
				// Grab resulting User object and Ref
				DynamicJsonObject myUser = new DynamicJsonObject();
				myUser = queryUserResults.Results.First();
				String myUserRef = myUser["_ref"];
				//Set our Workspace and Project scopings
				String workspaceRef = "/workspace/12345678910";
				String projectRef = "/project/12345678911";
				bool projectScopingUp = false;
				bool projectScopingDown = true;
				// Get handle to SCM Repository
				Request scmRequest = new Request("SCMRepository");
				scmRequest.Fetch = new List<string>()
					{
						"ObjectID",
						"Name",
						"SCMType"
					};
				// Add query
				scmRequest.Query = new Query("Name", Query.Operator.Equals, scmRepositoryName);
				// Query Rally
				QueryResult querySCMResults = restApi.Query(scmRequest);
				DynamicJsonObject myRepository = new DynamicJsonObject();
				myRepository = querySCMResults.Results.First();
				// Find User Story that we want to add Changeset to
				// Tee up Story Request
				Request storyRequest = new Request("hierarchicalrequirement");
				storyRequest.Workspace = workspaceRef;
				storyRequest.Project = projectRef;
				storyRequest.ProjectScopeDown = projectScopingDown;
				storyRequest.ProjectScopeUp = projectScopingUp;
				// Fields to Fetch
				storyRequest.Fetch = new List<string>()
					{
						"Name",
						"FormattedID",
						"Changesets"
					};
				// Add a query
				storyRequest.Query = new Query("FormattedID", Query.Operator.Equals, storyFormattedID);
				// Query Rally for the Story
				QueryResult queryResult = restApi.Query(storyRequest);
				// Pull reference off of Story fetch
				var storyObject = queryResult.Results.First();
				String storyReference = storyObject["_ref"];
				// Pull existing Changesets off of Story
				var existingChangesets = storyObject["Changesets"];
				Console.WriteLine("Story: " + storyFormattedID);
				Console.WriteLine("Number of Existing Changesets: " + existingChangesets.Count);
				// DynamicJSONObject for New Changeset
				DynamicJsonObject newChangeset = new DynamicJsonObject();
				// Commit Time Stamp
				String commitTimeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
			  
				// Populate Changeset Attributes
				newChangeset["SCMRepository"] = myRepository;
				newChangeset["Author"] = myUserRef;
				newChangeset["Revision"] = "2451";
				newChangeset["Uri"] = "https://svnrepo.company.com:8001";
				newChangeset["CommitTimestamp"] = commitTimeStamp;
				// Artifacts list
				var changeSetArtifacts = new ArrayList();
				changeSetArtifacts.Add(storyObject);
				// Update attribute on Changeset
				newChangeset["Artifacts"] = changeSetArtifacts;
				try
				{
					// Create the Changeset
					Console.WriteLine("Creating Rally Changeset...");
					CreateResult myChangesetCreateResult = restApi.Create("ChangeSet", newChangeset);
					String myChangesetRef = myChangesetCreateResult.Reference;
					Console.WriteLine("Successfully Created Rally Changeset: " + myChangesetRef);
					List<string> createWarnings = myChangesetCreateResult.Warnings;
					for (int i = 0; i < createWarnings.Count; i++)
					{
						Console.WriteLine(createWarnings[i]);
					}
					
					List<string> createErrors = myChangesetCreateResult.Errors;
					for (int i = 0; i < createErrors.Count; i++)
					{
						Console.WriteLine(createErrors[i]);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Exception occurred creating Rally Changeset: " + e.StackTrace);
					Console.WriteLine(e.Message);
				}
				Console.ReadKey();
			}
		}
	}
