     public List<CodeReviewComment> GetCodeReviewComments(int workItemId)
     {
            List<CodeReviewComment> comments = new List<CodeReviewComment>();
            Uri uri = new Uri(URL_TO_TFS_COLLECTION);
            TeamFoundationDiscussionService service = new TeamFoundationDiscussionService();
            service.Initialize(new Microsoft.TeamFoundation.Client.TfsTeamProjectCollection(uri));
            IDiscussionManager discussionManager = service.CreateDiscussionManager();
            IAsyncResult result = discussionManager.BeginQueryByCodeReviewRequest(workItemId, QueryStoreOptions.ServerAndLocal, new AsyncCallback(CallCompletedCallback), null);
            var output = discussionManager.EndQueryByCodeReviewRequest(result);
            foreach (DiscussionThread thread in output)
            {
                if (thread.RootComment != null)
                {
                    CodeReviewComment comment = new CodeReviewComment();
                    comment.Author = thread.RootComment.Author.DisplayName;
                    comment.Comment = thread.RootComment.Content;
                    comment.PublishDate = thread.RootComment.PublishedDate.ToShortDateString();
                    comment.ItemName = thread.ItemPath;
                    comments.Add(comment);
                }
            }
            return comments;
        }
        static void CallCompletedCallback(IAsyncResult result)
        {
            // Handle error conditions here
        }
        public class CodeReviewComment
        {
            public string Author { get; set; }
            public string Comment { get; set; }
            public string PublishDate { get; set; }
            public string ItemName { get; set; }
        }
