    namespace RestExample_UpdateStoryTags
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                //Initialize the REST API
                RallyRestApi restApi;
                String rallyUserName = "user@company.com";
                String rallyPassword = "topsecret";
                String rallyURL = "https://rally1.rallydev.com";
                String wsapiVersion = "1.41";
                String myWorkspaceName = "My Workspace";
    
                restApi = new RallyRestApi(
                    rallyUserName,
                    rallyPassword,
                    rallyURL,
                    wsapiVersion
                );
    
                // Get a Reference to Target Workspace
                Request workspaceRequest = new Request("workspace");
                workspaceRequest.Fetch = new List<string>()
                    {
                        "Name",
                        "ObjectID"
                    };
    
                workspaceRequest.Query = new Query("Name", Query.Operator.Equals, myWorkspaceName);
                QueryResult workspaceQueryResults = restApi.Query(workspaceRequest);
    
                var targetWorkspace = workspaceQueryResults.Results.First();
                Console.WriteLine("Found Target Workspace: " + targetWorkspace["Name"]);
    
                String workspaceRef = targetWorkspace["_ref"];
    
                //Query for Target Tag
                Request tagRequest = new Request("tag");
                tagRequest.Fetch = new List<string>()
                    {
                        "Name",
                        "ObjectID"
                    };
    
                // Query all Tags for a tag named "Montane"
                tagRequest.Query = new Query("Name", Query.Operator.Equals, "Tundra");
                QueryResult queryTagResults = restApi.Query(tagRequest);
    
                var targetTagResult = queryTagResults.Results.First();
                long tagOID = targetTagResult["ObjectID"];
    
                DynamicJsonObject targetTag = restApi.GetByReference("tag", tagOID, "Name", "ObjectID");
    
                // Query for User Story
                // FormattedID of target story
                String targetStoryFormattedID = "US5";
    
                Request storyRequest = new Request("hierarchicalrequirement");
                storyRequest.Fetch = new List<string>()
                    {
                        "Name",
                        "ObjectID",
                        "Iteration",
                        "FormattedID",
                        "Tags"
                };
    
    
                storyRequest.Query = new Query("FormattedID", Query.Operator.Equals, targetStoryFormattedID);
                QueryResult queryStoryResults = restApi.Query(storyRequest);
    
                var targetUserStory = queryStoryResults.Results.First();
                Console.WriteLine("Found Target User Story: " + targetUserStory["Name"]);
    
                // Grab collection of existing Tags
                var existingTags = targetUserStory["Tags"];
    
                // Summarize Existing Tags
                Console.WriteLine("Existing Tags for Story" + targetStoryFormattedID + ": ");
                foreach (var tag in existingTags)
                {
                    Console.WriteLine(tag["Name"]);
                }
    
                long targetOID = targetUserStory["ObjectID"];
    
                // Now do update of the User Story
    
                // Tags collection on object is expected to be a System.Collections.ArrayList
                var targetTagArray = existingTags;
                targetTagArray.Add(targetTag);
    
                DynamicJsonObject toUpdate = new DynamicJsonObject();
                toUpdate["Tags"] = targetTagArray;
    
                OperationResult updateResult = restApi.Update("HierarchicalRequirement", targetOID, toUpdate);
                foreach (var error in updateResult.Errors)
                {
                    Console.WriteLine(error.ToString());
                }
    
                // Re-read target Story
                DynamicJsonObject updatedStory = restApi.GetByReference(targetUserStory["_ref"], "Tags,Name");
                var updatedTags = updatedStory["Tags"];
    
                // Summarize Updated Tags
                Console.WriteLine("Updated Tags for Story" + targetStoryFormattedID + ": ");
                foreach (var tag in updatedTags)
                {
                    Console.WriteLine(tag["Name"]);
                }
    
                // Create a New Tag, and add New Tag to Story
                DynamicJsonObject newTag = new DynamicJsonObject();
                newTag["Name"] = "Boreal";
    
                CreateResult createResult = restApi.Create(workspaceRef, "Tag", newTag);
    
                // Get the ref of the created Tag
                String newTagRef = createResult.Reference;
    
                // Read the Target Tag
                DynamicJsonObject newTagRead = restApi.GetByReference(newTagRef, "Name");
                
                // Add the newly-created Tag to the Story
                targetTagArray.Add(newTagRead);
                toUpdate["Tags"] = targetTagArray;
    
                updateResult = restApi.Update("HierarchicalRequirement", targetOID, toUpdate);
    
                // Re-read target Story
                updatedStory = restApi.GetByReference(targetUserStory["_ref"], "Tags,Name");
                updatedTags = updatedStory["Tags"];
    
                // Summarize Updated Tags
                Console.WriteLine("Updated Tags (with newly-created Tag for Story" + targetStoryFormattedID + ": ");
                foreach (var tag in updatedTags)
                {
                    Console.WriteLine(tag["Name"]);
                }
                Console.ReadKey();
            }
        }
    }
