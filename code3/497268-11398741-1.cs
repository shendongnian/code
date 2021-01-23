	// System Libraries
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Drawing.Imaging;
	using System.Drawing;
	using System.IO;
	using System.Web;
	// Rally REST API Libraries
	using Rally.RestApi;
	using Rally.RestApi.Response;
	namespace RestExample_CreateAttachment
	{
		class Program
		{
			static void Main(string[] args)
			{
				// Set user parameters
				String userName = "user@company.com";
				String userPassword = "password";
				// Set Rally parameters
				String rallyURL = "https://rally1.rallydev.com";
				String rallyWSAPIVersion = "1.36";
				//Initialize the REST API
				RallyRestApi restApi;
				restApi = new RallyRestApi(userName,
										   userPassword,
										   rallyURL,
										   rallyWSAPIVersion);
				// Create Request for User
				Request userRequest = new Request("user");
				userRequest.Fetch = new List<string>()
					{
						"UserName",
						"Subscription",
						"DisplayName",
					};
				// Add a Query to the Request
				userRequest.Query = new Query("");
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
				// Find User Story that we want to add attachment to
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
						"FormattedID"
					};
				// Add a query
				storyRequest.Query = new Query("FormattedID", Query.Operator.Equals, "US43");
				// Query Rally for the Story
				QueryResult queryResult = restApi.Query(storyRequest);
				// Pull reference off of Story fetch
				var storyObject = queryResult.Results.First();
				String storyReference = storyObject["_ref"];
				// Read In Image Content
				String imageFilePath = "C:\\Users\\username\\";
				String imageFileName = "image1.png";
				String fullImageFile = imageFilePath + imageFileName;
				Image myImage = Image.FromFile(fullImageFile);
				// Get length from Image.Length attribute - don't use this in REST though
				// REST expects the length of the image in number of bytes as converted to a byte array
				var imageFileLength = new FileInfo(fullImageFile).Length;
				Console.WriteLine("Image File Length from System.Drawing.Image: " + imageFileLength);
				// Convert Image to Base64 format
				string imageBase64String = ImageToBase64(myImage, System.Drawing.Imaging.ImageFormat.Png);           
				// Length calculated from Base64String converted back
				var imageNumberBytes = Convert.FromBase64String(imageBase64String).Length;
				// This differs from just the Length of the Base 64 String!
				Console.WriteLine("Image File Length from Convert.FromBase64String: " + imageNumberBytes);
				// DynamicJSONObject for AttachmentContent
				DynamicJsonObject myAttachmentContent = new DynamicJsonObject();
				myAttachmentContent["Content"] = imageBase64String;
				try
				{
					CreateResult myAttachmentContentCreateResult = restApi.Create("AttachmentContent", myAttachmentContent);
					String myAttachmentContentRef = myAttachmentContentCreateResult.Reference;
					Console.WriteLine("Created: " + myAttachmentContentRef);
					// DynamicJSONObject for Attachment Container
					DynamicJsonObject myAttachment = new DynamicJsonObject();
					myAttachment["Artifact"] = storyReference;
					myAttachment["Content"] = myAttachmentContentRef;
					myAttachment["Name"] = "AttachmentFromREST.png";
					myAttachment["Description"] = "Attachment Desc";
					myAttachment["ContentType"] = "image/png";
					myAttachment["Size"] = imageNumberBytes;
					myAttachment["User"] = myUserRef;
					CreateResult myAttachmentCreateResult = restApi.Create("Attachment", myAttachment);
					List<string> createErrors = myAttachmentContentCreateResult.Errors;
					for (int i = 0; i < createErrors.Count; i++)
					{
						Console.WriteLine(createErrors[i]);
					}
					String myAttachmentRef = myAttachmentCreateResult.Reference;
					Console.WriteLine("Created: " + myAttachmentRef);
				}
				catch (Exception e)
				{
					Console.WriteLine("Unhandled exception occurred: " + e.StackTrace);
					Console.WriteLine(e.Message);
				}
			}
			// Converts image to Base 64 Encoded string
			public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
			{
				using (MemoryStream ms = new MemoryStream())
				{
					image.Save(ms, format);
					// Convert Image to byte[]                
					byte[] imageBytes = ms.ToArray();
					// Convert byte[] to Base64 String
					string base64String = Convert.ToBase64String(imageBytes);
					return base64String;
				}
			}
		}
	}
