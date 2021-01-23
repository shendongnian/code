    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using Rally.RestApi;
    using Rally.RestApi.Response;
    
    namespace DownloadAttachment
    {
        class Program
        {
            static void Main(string[] args)
            {
                RallyRestApi restApi;
    
                String userName = "user@co.com";
                String userPassword = "secret";
    
                String rallyURL = "https://rally1.rallydev.com";
                String wsapiVersion = "v2.0";
    
                restApi = new RallyRestApi(
                    userName,
                    userPassword,
                    rallyURL,
                    wsapiVersion
                );
    
                String workspaceRef = "/workspace/12352608129";
                String projectRef = "/project/12352608219";
                bool projectScopingUp = false;
                bool projectScopingDown = true;
    
                Request storyRequest = new Request("hierarchicalrequirement");
                storyRequest.Workspace = workspaceRef;
                storyRequest.Project = projectRef;
                storyRequest.ProjectScopeDown = projectScopingDown;
                storyRequest.ProjectScopeUp = projectScopingUp;
    
                storyRequest.Fetch = new List<string>()
                    {
                        "Name",
                        "FormattedID",
                        "Attachments"
                    };
    
                storyRequest.Query = new Query("FormattedID", Query.Operator.Equals, "US20");
                QueryResult queryResult = restApi.Query(storyRequest);
                DynamicJsonObject story = queryResult.Results.First();
    
                // Grab the Attachments collection
                Request attachmentsRequest = new Request(story["Attachments"]);
                QueryResult attachmentsResult = restApi.Query(attachmentsRequest);
    		
                //Download the first attachment
    
                var myAttachmentFromStory = attachmentsResult.Results.First();
                String myAttachmentRef = myAttachmentFromStory["_ref"];
                Console.WriteLine("Found Attachment: " + myAttachmentRef);
    
                // Fetch fields for the Attachment
                string[] attachmentFetch = { "ObjectID", "Name", "Content", "ContentType", "Size" };
    
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
                String attachmentSavePath = "C:\\Users\\nmusaelian\\NewFolder";
                String attachmentFileName = attachmentObject["Name"];
                String fullAttachmentFile = attachmentSavePath + attachmentFileName;
    
                // Determine attachment Content mime-type
                String attachmentContentType = attachmentObject["ContentType"];
    
                // Specify Image format
                System.Drawing.Imaging.ImageFormat attachmentImageFormat;
    
                try
                {
                    attachmentImageFormat = getImageFormat(attachmentContentType);
                }
                catch (System.ArgumentException e)
                {
                    Console.WriteLine("Invalid attachment file format:" + e.StackTrace);
                }
    
                try
                {
    
                    // Convert base64 content to Image
                    Console.WriteLine("Converting base64 AttachmentContent String to Image.");
    
                    // Convert Base64 string to bytes
                    byte[] bytes = Convert.FromBase64String(base64EncodedContent);
    
                    Image myAttachmentImage;
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        myAttachmentImage = Image.FromStream(ms);
                        // Save the image
                        Console.WriteLine("Saving Image: " + fullAttachmentFile);
                        myAttachmentImage.Save(fullAttachmentFile, System.Drawing.Imaging.ImageFormat.Jpeg);
    
                        Console.WriteLine("Finished Saving Attachment: " + fullAttachmentFile);
                    }
    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unhandled exception occurred: " + e.StackTrace);
                    Console.WriteLine(e.Message);
                }
    
                Console.ReadKey();
            }
    
            // Returns an ImageFormat type based on Rally contentType / mime-type
            public static System.Drawing.Imaging.ImageFormat getImageFormat(String contentType)
            {
                // Save Image format
                System.Drawing.Imaging.ImageFormat attachmentImageFormat;
    
                switch (contentType)
                {
                    case "image/png":
                        attachmentImageFormat = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    case "image/jpeg":
                        attachmentImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case "image/tiff":
                        attachmentImageFormat = System.Drawing.Imaging.ImageFormat.Tiff;
                        break;
                    default:
                        Console.WriteLine("Invalid image file format.");
                        throw new System.ArgumentException("Invalid attachment file format.");
                };
    
                return attachmentImageFormat;
            }
        }
    }
