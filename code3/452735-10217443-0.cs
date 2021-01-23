    using System;
    using Google.GData.Client;
    using Google.GData.Client.ResumableUpload;
    using Google.GData.Documents;
    namespace MyDocumentsListIntegration
    {
      class Program
      {
        static void Main(string[] args)
        {
          DocumentsService service = new DocumentsService("MyDocumentsListIntegration-v1");
          // TODO: Instantiate an Authenticator object according to your authentication
          // mechanism (e.g. OAuth2Authenticator).
          // Authenticator authenticator =  ...
          // Instantiate a DocumentEntry object to be inserted.
          DocumentEntry entry = new DocumentEntry();
          // Set the document title
          entry.Title.Text = "Legal Contract";
          // Set the media source
          entry.MediaSource = new MediaFileSource("c:\\contract.txt", "text/plain");
          // Define the resumable upload link
          Uri createUploadUrl = new Uri("https://docs.google.com/feeds/upload/create-session/default/private/full");
          AtomLink link = new AtomLink(createUploadUrl.AbsoluteUri);
          link.Rel = ResumableUploader.CreateMediaRelation;
          entry.Links.Add(link);
          // Set the service to be used to parse the returned entry
          entry.Service = service;
          // Instantiate the ResumableUploader component.
          ResumableUploader uploader = new ResumableUploader();
          // Set the handlers for the completion and progress events
          uploader.AsyncOperationCompleted += new AsyncOperationCompletedEventHandler(OnDone);
          uploader.AsyncOperationProgress += new AsyncOperationProgressEventHandler(OnProgress);
          // Start the upload process
          uploader.InsertAsync(authenticator, entry, new object());
        }
        static void OnDone(object sender, AsyncOperationCompletedEventArgs e) {
            DocumentEntry entry = e.Entry as DocumentEntry;
        }
        static void OnProgress(object sender, AsyncOperationProgressEventArgs e) {
            int percentage = e.ProgressPercentage;
        }
      }
    }
