	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Drawing;
	using System.Drawing.Imaging;
	using System.IO;
	using Rally.RestApi;
	using Rally.RestApi.Response;
	namespace RestExample_DownloadAttachment
	{
		class Program
		{
			static void Main(string[] args)
			{
				 //Initialize the REST API
				RallyRestApi restApi;
				// Rally parameters
				String userName = "user@company.com";
				String userPassword = "topsecret";
				String rallyURL = "https://rally1.rallydev.com";
				String wsapiVersion = "1.43";
				restApi = new RallyRestApi(
					userName,
					userPassword,
					rallyURL,
					wsapiVersion
				);
				//Set our Workspace and Project scopings
				String workspaceRef = "/workspace/12345678910";
				String projectRef = "/project/12345678911";
				bool projectScopingUp = false;
				bool projectScopingDown = true;
				// Find User Story that we want to pull attachment from
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
						"Attachments"
					};
				// Add a query
				storyRequest.Query = new Query("FormattedID", Query.Operator.Equals, "US163");
				// Query Rally for the Story
				QueryResult queryResult = restApi.Query(storyRequest);
				// Pull reference off of Story fetch
				DynamicJsonObject storyObject = queryResult.Results.First();
				String storyReference = storyObject["_ref"];
				Console.WriteLine("Looking for attachments off of Story: " + storyReference);
				// Grab the Attachments collection
				var storyAttachments = storyObject["Attachments"];
				// Let's download the first attachment for starters
				var myAttachmentFromStory = storyAttachments[0];
				// Pull the ref
				String myAttachmentRef = myAttachmentFromStory["_ref"];
				Console.WriteLine("Found Attachment: " + myAttachmentRef);
				// Fetch fields for the Attachment
				string[] attachmentFetch = { "ObjectID", "Name", "Content", "ContentType", "Size"};
				// Now query for the attachment
				DynamicJsonObject attachmentObject = restApi.GetByReference(myAttachmentRef, "true");
				// Grab the AttachmentContent
				DynamicJsonObject attachmentContentFromAttachment = attachmentObject["Content"];
				String attachmentContentRef = attachmentContentFromAttachment["_ref"];
				// Lastly pull the content
				// Fetch fields for the Attachment
				string[] attachmentContentFetch = { "ObjectID", "Content" };
				// Now query for the attachment
				Console.WriteLine("Querying for Content...");
				DynamicJsonObject attachmentContentObject = restApi.GetByReference(attachmentContentRef, "true");
				Console.WriteLine("AttachmentContent: " + attachmentObject["_ref"]);
				String base64EncodedContent = attachmentContentObject["Content"];
				// File information
				String attachmentSavePath = "C:\\Users\\markwilliams\\";
				String attachmentFileName = attachmentObject["Name"];
				String fullAttachmentFile = attachmentSavePath + attachmentFileName; 
				// Determine attachment Content mime-type
				String attachmentContentType = attachmentObject["ContentType"];
				try {
					// Output base64 content to File
					Console.WriteLine("Saving base64 AttachmentContent String to File.");
					File.WriteAllBytes(@fullAttachmentFile, Convert.FromBase64String(base64EncodedContent));
				}
				catch (Exception e)
				{
					Console.WriteLine("Unhandled exception occurred while writing file: " + e.StackTrace);
					Console.WriteLine(e.Message);
				}
					
				Console.ReadKey();
			}
		}
	}
